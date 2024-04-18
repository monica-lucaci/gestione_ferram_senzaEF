using Ferramenta_correzione.DTO;
using Ferramenta_correzione.Models;
using Ferramenta_correzione.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ferramenta_correzione.Services
{
    public class ProdottoService : IService<Prodotto>
    {
        private readonly ProdottoRepo _repository;

        public ProdottoService(ProdottoRepo repository)
        {
            _repository = repository;
        }

        public IEnumerable<Prodotto> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<ProdottoDto> RestituisciTutti()
        {
            List<ProdottoDto> elenco = this.PrendiliTutti().Select(p => new ProdottoDto()
            {
                Nom = p.Nome,
                Cat = p.Categoria,
                Cod = p.Codice,
                Des = p.Descrizione,
                Pre = p.Prezzo,
                Qua = p.Quantita
            }).ToList();

            return elenco;
        }


        public List<ProdottoDto> RestituisciProdottiFiltrati()
        {
            List<ProdottoDto> elenco = this.PrendiliTutti()
                .Where(e => e.Categoria != "VM")
                .Select(p => new ProdottoDto()
                {
                    Nom = p.Nome,
                    Cat = p.Categoria,
                    Cod = p.Codice,
                    Des = p.Descrizione,
                    Pre = p.Prezzo,
                    Qua = p.Quantita
                })
                .ToList();

            return elenco;
        }

        public bool InserisciProdotto(ProdottoDto oPro)
        {
            Prodotto pro = new Prodotto()
            {
                Categoria = oPro.Cat,
                Codice = Guid.NewGuid().ToString().ToUpper(),
                Descrizione = oPro.Des,
                Nome = oPro.Nom,
                Quantita = oPro.Qua,
                Prezzo = oPro.Pre,
                DataCreazione = DateTime.Now
            };

            return _repository.Create(pro);
        }

        public bool EliminaProdotto(ProdottoDto oPro)
        {
            if (oPro.Cod is not null)
            {
                Prodotto? temp = _repository.GetByCodice(oPro.Cod);

                if (temp is not null)
                    return _repository.Delete(temp.ProdottoId);
            }
            return false;
        }



        public bool IncrDecr(ProdottoDto oPro, bool varMood  )
        {
            if (oPro.Cod is not null)
            {
                Prodotto? temp = _repository.GetByCodice(oPro.Cod);
                if (temp is not null)
                {
                    temp.Quantita++;
                    return _repository.Update(temp);
                }
            }
            return false;
        }



        public bool Incrementa(ProdottoDto oPro)
        {
            if(oPro.Cod is not null)
            {
                Prodotto? temp = _repository.GetByCodice(oPro.Cod);
                if(temp is not null){
                    temp.Quantita++;
                    return _repository.Update(temp);
                }
            }
            return false;
        }
    }
}
