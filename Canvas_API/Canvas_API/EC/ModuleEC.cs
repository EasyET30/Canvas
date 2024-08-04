
using Canvas_API.Databases;
using Library_Canvas.DTO;
using Library_Canvas.Models;

namespace Canvas_API.EC
{
    public class ModuleEC
    {
        Filebase Database;
        public ModuleEC(){
            Database = Filebase.Current;
        }
        public ModuleDTO? AddOrUpdate(ModuleDTO dto)
        {
            Module created = new Module(dto);
            var id = Database.AddOrUpdateModule(created);
            return Get(id);
        }
        public ModuleDTO? Get(string Id)
        {
            var returnVal = Database.Modules.FirstOrDefault(p=>p.Id == Id) ?? new Module();
            return new ModuleDTO(returnVal);
        }
        public bool Delete(string Id)
        {
            bool returnVal = Database.Delete("Module", Id);
            return returnVal;
        }
        public IEnumerable<ModuleDTO> Search(string query = "")
        {
            return Database.Modules.Where(m => m.Name.ToUpper().Contains(query.ToUpper())).Select(m => new ModuleDTO(m));
        }
        
    }
}
