
using Canvas_API.Databases;
using Library_Canvas.DTO;
using Library_Canvas.Models;

namespace Canvas_API.EC
{
    public class ContentItemEC
    {
        Filebase Database;
        public ContentItemEC(){
            Database = Filebase.Current;
        }
        public ContentItemDTO? AddOrUpdate(ContentItemDTO dto)
        {
            ContentItem created = new ContentItem(dto);
            var id = Database.AddOrUpdateContentItem(created);
            return Get(id);
        }
        public ContentItemDTO? Get(string Id)
        {
            var returnVal = Database.Contents.FirstOrDefault(p=>p.Id == Id) ?? new ContentItem();
            return new ContentItemDTO(returnVal);
        }
        public bool Delete(string Id)
        {
            bool returnVal = Database.Delete("ContentItem", Id);
            return returnVal;
        }
        public IEnumerable<ContentItemDTO> Search(string query = "")
        {
            return Database.Contents.Where(m => m.Name.ToUpper().Contains(query.ToUpper())).Select(m => new ContentItemDTO(m));
        }
        
    }
}
