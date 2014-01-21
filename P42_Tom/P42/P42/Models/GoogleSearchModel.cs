using Microsoft.Practices.Prism.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P42.Models
{
    public class GoogleSearchModel : ViewModelBase
    {
        #region Deklaration

        private ObservableCollection<Link> mURLs = new ObservableCollection<Link>();
        public ObservableCollection<Link> URLs
        {
            get { return (mURLs); }
            set { mURLs = value; RaisePropertyChanged("URLs"); }
        }


        private string mSearchText;
        public string SearchText
        {
            get { return (mSearchText); }
            set { mSearchText = value; RaisePropertyChanged("SearchText"); }
        }

        #endregion

        #region Properties

        public DelegateCommand SearchCommand { get; set; }

        #endregion

        #region Konstruktor

        public GoogleSearchModel()
        {
            SearchCommand = new DelegateCommand(GoogleSearch);
            SearchText = "Suchen";
            URLs.CollectionChanged += URLs_CollectionChanged;
        }

        void URLs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("URLs");
        }

        #endregion

        #region Events

        public override void OverrideMe()
        {
            base.OverrideMe();

        }

        #endregion

        #region Diverses

        private void GoogleSearch()
        {
            URLs.Clear();
            var client = new HttpClient();
            var address = new Uri("https://ajax.googleapis.com/ajax/services/search/web?v=1.0&q=" + SearchText);

            string stream = new System.Net.WebClient().DownloadString(address);
            dynamic res = JsonConvert.DeserializeObject(stream);

            foreach (var r in res.responseData.results)
            {
                URLs.Add(new Link() { Caption = r.titleNoFormatting.ToString(), URL = r.url.ToString() });
            }
            RaisePropertyChanged("CurrentResponse");
        }

        #endregion

        #region Google JSON

        public sealed class Result
        {
            public string GsearchResultClass { get; set; }
            public string unescapedUrl { get; set; }
            public string url { get; set; }
            public string visibleUrl { get; set; }
            public string cacheUrl { get; set; }
            public string title { get; set; }
            public string titleNoFormatting { get; set; }
            public string content { get; set; }
        }

        public sealed class Page
        {
            public string start { get; set; }
            public int label { get; set; }
        }

        public sealed class Cursor
        {
            public string resultCount { get; set; }
            public List<Page> pages { get; set; }
            public string estimatedResultCount { get; set; }
            public int currentPageIndex { get; set; }
            public string moreResultsUrl { get; set; }
            public string searchResultTime { get; set; }
        }

        public sealed class ResponseData
        {
            public List<Result> results { get; set; }
            public Cursor cursor { get; set; }
        }

        public sealed class RootObject
        {
            public ResponseData responseData { get; set; }
            public object responseDetails { get; set; }
            public int responseStatus { get; set; }
        }


        #endregion

       

    }


    public struct Link
    {
        private string mCaption;

        public string Caption
        {
            get { return mCaption; }
            set { mCaption = value; }
        }


        private string mURL;

        public string URL
        {
            get { return mURL; }
            set { mURL = value; }
        }

    }
}
