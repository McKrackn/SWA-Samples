using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ReadWebPage
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<string> HeadLines { get; private set; } = new ObservableCollection<string>();

        private object _locker = new object();
        private SemaphoreSlim _sem = new SemaphoreSlim(1, 1);
        private string _status = null;

        public string Status
        {
            get => _status;
            set => this.Set(ref _status, value, nameof(Status));
        }


        public RelayCommand GetDataCommand { get; }
        public RelayCommand GetDataAsyncCommand { get; }
        public RelayCommand GetDataAsyncNewTaskCommand { get; }
        public MainViewModel()
        {
            GetDataCommand = new RelayCommand(() => GetData());
            GetDataAsyncCommand = new RelayCommand(() => GetDataAsync());
            GetDataAsyncNewTaskCommand = new RelayCommand(() => GetDataAsyncNewTask());
        }

        public void GetData()
        {
            Status = $"Get Data - " + DateTime.Now.ToLongTimeString();

            // 1)
            // HeadLines.Add("hallo"); // basic test that data binding works


            // 2)
            WebClient client = new WebClient();
            var content = client.DownloadString("https://sport.orf.at/");
            Thread.Sleep(10_000);

            var regexFindHeadlines = new Regex("ticker-story-headline.*?a\\ href.*?>(.*?)<\\/a",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

            HeadLines.Clear();
            var matches = regexFindHeadlines.Matches(content);
            foreach (Match match in matches)
            {
                var myHeadline = match.Groups[1].ToString().Trim();
                HeadLines.Add(myHeadline);
            }
        }

        public async Task GetDataAsync()
        {
            Status = $"Get Data Async - " + DateTime.Now.ToLongTimeString();
            HeadLines.Clear();

            WebClient client = new WebClient();
            var content = client.DownloadStringTaskAsync("https://sport.orf.at/");
            //await Task.Delay(30_000);
            var regexFindHeadlines = new Regex("ticker-story-headline.*?a\\ href.*?>(.*?)<\\/a",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var matches = regexFindHeadlines.Matches(await content);
            // Monitor 
            // lock (_locker) // not usable with async/await
            {
                try
                {
                    await _sem.WaitAsync();

                    foreach (Match match in matches)
                    {
                        var myHeadline = match.Groups[1].ToString().Trim();
                        // Thread.Sleep(100); // use in combination with lock, but not responsive
                        await Task.Delay(1000); // use in combination with Semaphore... more complex
                        HeadLines.Add(myHeadline);
                    }
                }
                // in case an error happens in the critical section we still need to free the sem
                // else we can not enter the critical section anymore
                finally
                {
                    _sem.Release();
                }
            }
        }

        public async void GetDataAsyncNewTask()
        {
            await Task.Run(async () =>
            {
                // await GetDataAsync(); // does not work, because objects are owned by another thread

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Status = $"Get Data Async - " + DateTime.Now.ToLongTimeString();
                    HeadLines.Clear();
                });


                WebClient client = new WebClient();
                var content = client.DownloadStringTaskAsync("https://sport.orf.at/");
                var regexFindHeadlines = new Regex("ticker-story-headline.*?a\\ href.*?>(.*?)<\\/a",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline);

                var matches = regexFindHeadlines.Matches(await content);
                try
                {
                    await _sem.WaitAsync();

                    foreach (Match match in matches)
                    {
                        var myHeadline = match.Groups[1].ToString().Trim();
                        await Task.Delay(1000); // use in combination with Semaphore... more complex

                        Application.Current.Dispatcher.Invoke(() => { HeadLines.Add(myHeadline); });
                    }
                }
                // in case an error happens in the critical section we still need to free the sem
                // else we can not enter the critical section anymore
                finally
                {
                    _sem.Release();
                }
            });
        }

    }
}
