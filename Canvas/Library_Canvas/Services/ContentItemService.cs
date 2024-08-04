using System.Text.Json;
using Library_Canvas.DTO;
using Library_Canvas.Utilities;

namespace Library_Canvas.Services
{
    public class ContentItemService
    {
        private List<ContentItemDTO> contentItems;
        public List<ContentItemDTO> ContentItems { 
            get {
                
                return contentItems ?? new List<ContentItemDTO>();
            } 
        }

        //private List<ContentItem> ContentItems;

        private static ContentItemService? instance;

        public static ContentItemService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContentItemService();
                }
                return instance;
            }
        }
        private ContentItemService()
        {
            var response = new WebRequestHandler().Get("/ContentItem").Result;
            contentItems = JsonSerializer.Deserialize<List<ContentItemDTO>>(response)?? new List<ContentItemDTO>();
        }

        public void Delete(string Id)
        {
            var handler = new WebRequestHandler().Delete($"/ContentItem/Delete/{Id}");
            var ContentItemToDelete = ContentItems.FirstOrDefault(c => c.Id == Id);
            if(ContentItemToDelete != null)
            {
                ContentItems.Remove(ContentItemToDelete);
            }
        }

        public void AddOrUpdate(ContentItemDTO c)
        {
            var response = new WebRequestHandler().Post("/ContentItem/Post", c).Result;
            var myUpdatedContentItem = JsonSerializer.Deserialize<ContentItemDTO>(response);
            if(myUpdatedContentItem != null)
            {
                var existingContentItem = ContentItems.FirstOrDefault(c => c.Id == myUpdatedContentItem.Id);
                if(existingContentItem == null)
                {
                    ContentItems.Add(myUpdatedContentItem);
                }else
                {
                    var index = ContentItems.IndexOf(existingContentItem);
                    ContentItems.RemoveAt(index);
                    ContentItems.Insert(index, myUpdatedContentItem);
                }
            }

        }

        public ContentItemDTO? Get(string Id)
        {
            var response = new WebRequestHandler()
                    .Get($"/ContentItem/GetById/{Id}")
                    .Result;
            var ContentItem = JsonSerializer.Deserialize<ContentItemDTO>(response);
            return ContentItem;
            //return ContentItems.FirstOrDefault(c => c.Id == Id);
        }

        public IEnumerable<ContentItemDTO> Search(string query)
        {
            return ContentItems
                .Where(c => c.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}
