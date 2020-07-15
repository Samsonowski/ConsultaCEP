using ConsultaCEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCEP.DAL
{
    public class CepDAO
    {
        private readonly Context _context;
        public CepDAO(Context context)
        {
            _context = context;
        }

        public void Create(Cep cep)
        {
            _context.Ceps.Add(cep);
            _context.SaveChanges();
        }

        public List<Cep> List()
        {
            return _context.Ceps.ToList();
        }

        public Cep List(string cep)
        {
            string str1 = cep.Substring(0, 5);
            string str2 = cep.Substring(5, 3);
            string str = $"{str1}-{str2}";
            return _context.Ceps.First(c => c.cep == str);
        }

        public Cep Update(Cep cep)
        {
            _context.Ceps.Update(cep);
            _context.SaveChanges();
            return _context.Ceps.First(c => c == cep);
        }

        public Cep Delete(string id)
        {
            Cep cep = _context.Ceps.Find(int.Parse(id));
            _context.Ceps.Remove(cep);
            _context.SaveChanges();
            return cep;
        }
    }
}
