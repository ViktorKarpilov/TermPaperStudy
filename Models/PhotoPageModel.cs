using System.Collections.Generic;

namespace TermPaper.Models
{
    public class PhotoPageModel
    {
        public int counter {get;private set;} = 0;


        //name:Url
        public Dictionary<string,string> Photos {get;private set;}

        public ImageCommentsModel CommentsModel { get; set; }

        public PhotoPageModel(Dictionary<string,string> Photos){
             this.counter = Photos.Count;
             this.Photos = Photos;
         }

        public PhotoPageModel(Dictionary<string,string> Photos,ImageCommentsModel comments){
            this.counter = Photos.Count;
            this.Photos = Photos;
            CommentsModel = comments;
        }

         public PhotoPageModel(string name,string url){
             this.counter++;
             this.Photos = new Dictionary<string, string>();
             this.Photos.Add(name,url);
         }

         public void AddCommentsModel(ImageCommentsModel comments){
             this.CommentsModel = comments;
         }

         
        
    }
}