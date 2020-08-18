using DB.Models;
using DB.ViewModels;
using Logic.Extensions;
using Logic.Repository.Interfaces;

namespace Logic.Repository
{
    public class CvRepository : Repository<Cv>, ICvRepository
    {
        public override bool Add(Cv model, params object[] parameters)
        {
            var cv = model as CvViewModel;
            if (cv.File != null)
            {
                cv.B64 = cv.File.PDFToBase64();
            }
            return _context.AddEntity(model) > 0;
        }
    }
}