using DB.Models;
using DB.ViewModels;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class PersonLogic : IDatabaseFunctions<PersonViewModel, Kisi>
    {
        public bool Add(PersonViewModel model, params object[] parameters)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                var file = model.File.ImageToBase64();
                if (file != null)
                {
                    var person = model.Kisi;
                    string ehliyetler = null;
                    model.Ehliyetler.ForEach(x => ehliyetler += x + ",");
                    person.Ehliyet = ehliyetler.Remove(ehliyetler.Length - 1);
                    person.EklemeTarihi = DateTime.Now;
                    person.Fotograf = file;
                    db.Kisi.Add(person);
                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public bool Delete(int? id)
        {
            return false;
        }

        public Kisi GetFromId(int? id)
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Kisi.Find(id);
        }

        public List<Kisi> GetList()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Kisi.ToList();
        }

        public Kisi GetPerson()
        {
            using PersonalWebSiteContext db = new PersonalWebSiteContext();
            return db.Kisi.AsEnumerable().LastOrDefault();
        }

        public bool Update(PersonViewModel model)
        {
            bool success = false;
            if (model != null)
            {
                using PersonalWebSiteContext db = new PersonalWebSiteContext();
                var person = db.Kisi.AsEnumerable().LastOrDefault();
                if (person != null)
                {
                    person.DegisimTarihi = DateTime.Now;
                    person.Adi = model.Kisi.Adi;
                    person.Soyadi = model.Kisi.Soyadi;
                    person.Eposta = model.Kisi.Eposta;
                    person.Telefon = model.Kisi.Telefon;
                    person.CepTelefonu = model.Kisi.CepTelefonu;
                    person.SabitTelefonu = model.Kisi.SabitTelefonu;
                    person.Faks = model.Kisi.Faks;
                    person.SigaraKullanımDurumu = model.Kisi.SigaraKullanımDurumu;
                    person.AlkolKullanımDurumu = model.Kisi.AlkolKullanımDurumu;
                    person.EngelDurumu = model.Kisi.EngelDurumu;
                    person.SeyahatEngeliDurumu = model.Kisi.SeyahatEngeliDurumu;
                    string ehliyetler = null;
                    model.Ehliyetler.ForEach(x => ehliyetler += x + ",");
                    person.Ehliyet = ehliyetler.Remove(ehliyetler.Length - 1);
                    person.KanGrubu = model.Kisi.KanGrubu;
                    person.MedeniDurum = model.Kisi.MedeniDurum;
                    person.Cinsiyet = model.Kisi.Cinsiyet;
                    person.DogumTarihi = model.Kisi.DogumTarihi;
                    person.AskerlikDurumu = model.Kisi.AskerlikDurumu;
                    person.TecilTarihi = model.Kisi.TecilTarihi;
                    person.Meslek = model.Kisi.Meslek;
                    person.DogumSehirId = model.Kisi.DogumSehirId;
                    person.DogumIlceId = model.Kisi.DogumIlceId;
                    person.KonumSehirId = model.Kisi.KonumSehirId;
                    person.KonumIlceId = model.Kisi.KonumIlceId;
                    person.Uyruk = model.Kisi.Uyruk;
                    person.IsAramaDurumu = model.Kisi.IsAramaDurumu;
                    person.KariyerHedefi = model.Kisi.KariyerHedefi;
                    person.OnYazi = model.Kisi.OnYazi;
                    person.UcretBeklentisi = model.Kisi.UcretBeklentisi;
                    person.CalismakIstenilenSehir = model.Kisi.CalismakIstenilenSehir;
                    if (model.File != null)
                        person.Fotograf = model.File.ImageToBase64();

                    if (db.SaveChanges() > 0)
                        success = true;
                }
            }
            return success;
        }

        public PersonViewModel GetPersonViewModel()
        {
            PersonViewModel model = new PersonViewModel();
            var kisi = GetPerson();
            if (kisi != null)
            {
                model.Kisi = kisi;
                model.Ehliyetler = new List<string>();
                kisi.Ehliyet.Split(',').ToList().ForEach(x => model.Ehliyetler.Add(x));
            }
            return model;
        }
    }
}