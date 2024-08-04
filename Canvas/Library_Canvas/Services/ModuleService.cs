using System.Text.Json;
using Library_Canvas.DTO;
using Library_Canvas.Utilities;

namespace Library_Canvas.Services
{
    public class ModuleService
    {
        private List<ModuleDTO> modules;
        public List<ModuleDTO> Modules { 
            get {
                
                return modules ?? new List<ModuleDTO>();
            } 
        }

        //private List<Module> Modules;

        private static ModuleService? instance;

        public static ModuleService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModuleService();
                }
                return instance;
            }
        }
        private ModuleService()
        {
            var response = new WebRequestHandler().Get("/Module").Result;
            modules = JsonSerializer.Deserialize<List<ModuleDTO>>(response)?? new List<ModuleDTO>();
        }

        public void Delete(string Id)
        {
            var handler = new WebRequestHandler().Delete($"/Module/Delete/{Id}");
            var ModuleToDelete = Modules.FirstOrDefault(c => c.Id == Id);
            if(ModuleToDelete != null)
            {
                Modules.Remove(ModuleToDelete);
            }
        }

        public void AddOrUpdate(ModuleDTO c)
        {
            var response = new WebRequestHandler().Post("/Module/Post", c).Result;
            var myUpdatedModule = JsonSerializer.Deserialize<ModuleDTO>(response);
            if(myUpdatedModule != null)
            {
                var existingModule = Modules.FirstOrDefault(c => c.Id == myUpdatedModule.Id);
                if(existingModule == null)
                {
                    Modules.Add(myUpdatedModule);
                }else
                {
                    var index = Modules.IndexOf(existingModule);
                    Modules.RemoveAt(index);
                    Modules.Insert(index, myUpdatedModule);
                }
            }

        }

        public ModuleDTO? Get(int Id)
        {
            var response = new WebRequestHandler()
                    .Get($"/Module/GetById/{Id}")
                    .Result;
            var Module = JsonSerializer.Deserialize<ModuleDTO>(response);
            return Module;
            //return Modules.FirstOrDefault(c => c.Id == Id);
        }

        public IEnumerable<ModuleDTO> Search(string query)
        {
            return Modules
                .Where(c => c.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}
