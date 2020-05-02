using Microsoft.AspNetCore.Mvc;

namespace Logic.Interfaces
{
    public interface IControllerFunctions<T> where T : class
    {
        public IActionResult Add();
        public IActionResult Add(T model);
        public IActionResult Update();
        public IActionResult UpdateDb(T model);
        public IActionResult UpdatePage(int? id);
        public IActionResult List();
        public IActionResult Delete(int? id);
        public IActionResult Show(int? id);
    }
}