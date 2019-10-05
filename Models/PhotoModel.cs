using System.Collections.Generic;

namespace TermPaper.Models
{
    public class PhotoPageModel
    {
        public int counter {get;private set;} = 0;


        //name:Url
        public Dictionary<string,string> Photos {get;private set;}

         public PhotoPageModel(Dictionary<string,string> Photos){
             this.counter = Photos.Count;
             this.Photos = Photos;
         }

         public PhotoPageModel(string name,string url){
             this.counter++;
             this.Photos = new Dictionary<string, string>();
             this.Photos.Add(name,url);
         }
        
    }
}