using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace RecyclerView_Xamarin.Droid
{
    [Activity(Label = "BookStore", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        BookAdapter mAdapter;
        List<Book> books;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            books = await RestService.GetBooks();

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mAdapter = new BookAdapter(books);
            mAdapter.ItemClick += OnItemClick;
            mRecyclerView.SetAdapter(mAdapter);
        }

        void OnItemClick(object sender, int position)
        {
            int bookNum = position + 1;
            Toast.MakeText(this, "This is book number " + bookNum, ToastLength.Short).Show();
        }

    }

    public class BookViewHolder : RecyclerView.ViewHolder
    {
        public TextView Title { get; private set; }
        public TextView Body { get; private set; }
        
        public BookViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.title_txt);
            Body = itemView.FindViewById<TextView>(Resource.Id.body_txt);

            itemView.Click += (sender, e) => listener(base.Position);
        }
    }

    public class BookAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<Book> books;

        public BookAdapter(List<Book> books)
        {
            this.books = books;
        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.book_layout, parent, false);

            BookViewHolder vh = new BookViewHolder(itemView, OnClick);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            BookViewHolder vh = holder as BookViewHolder;

            vh.Title.Text = books[position].title;
            vh.Body.Text = books[position].body;
        }

        public override int ItemCount
        {
            get { return books.Count; }
        }

        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }

}


