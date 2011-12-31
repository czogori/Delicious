using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Delicious;
using Ninject;
using Delicious.Models;
using System.Xml.Linq;
using Delicious.Services;

namespace Delicious.Sample.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // init
            Configuration.Configure()
                .SetUserName("test")
                .SePassword("qwerty");

            IKernel kernel = new StandardKernel(new DeliciousModule());
            IPostService postService = kernel.Get<PostService>();
            ITagService tagService = kernel.Get<TagService>();
            IBundleService bundleService = kernel.Get<BundleService>();

            // test 

            ShowPosts(postService);
            //ShowTags(tagService);
            //ShowDeliciousDates(postService, "cqrs");            
            //ShowPostHashes(postService);
            //ShowSuggests(postService, "http://php.net");       

            //ShowBundles(bundleService);
        }

        static void ShowPosts(IPostService postService)
        {
            foreach (var post in postService.GetAll())
            {
                System.Console.WriteLine(post.Url + " " + post.Time.Year + " " + String.Join(",", post.Tags.Select(t => t.Name)));
            }        
        }

        static void ShowDeliciousDates(IPostService postService, string tag)
        {
            foreach (var date in postService.GetDeliciousDates(tag))
            {
                System.Console.WriteLine(date.Date + " " + date.Count);
            }
        }

        static void ShowPostHashes(IPostService postService)
        {
            foreach (var hash in postService.GetPostHashes())
            {
                System.Console.WriteLine(hash.Meta + " " + hash.Url);
            }
        }

        static void ShowSuggests(IPostService postService, string tag)
        {
            Suggest suggest = postService.GetSuggest(tag);
            System.Console.WriteLine("[Popular]");
            suggest.Popular.ForEach(System.Console.WriteLine);
            System.Console.WriteLine("[Recommended]");
            suggest.Recommended.ForEach(System.Console.WriteLine);
            System.Console.WriteLine("[Network]");
            suggest.Network.ForEach(System.Console.WriteLine);
        }

        static void ShowTags(ITagService tagService)
        {
            foreach (var tag in tagService.GetAll())
            {
                System.Console.WriteLine(tag.Name + " " + tag.Count);
            }
        }        

        static void ShowBundles(IBundleService bundleService, string bundleName = "")
        {
            foreach (var bundle in bundleService.GetAll(bundleName))
            {
                System.Console.WriteLine(bundle.Name + " " + string.Join(", ", bundle.Tags));
            }
        }
        
    }
}
