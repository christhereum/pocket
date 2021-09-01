using PocketApi.CustomModels;
using PocketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocketApi.AdelantoData
{
    public class DbAdelantoData : IAdelantoData
    {
        private PocketContext _pocketContext;
        public DbAdelantoData(PocketContext pocketContext)
        {
            _pocketContext = pocketContext;
        }

        public string GetUltimoIdAdelanto()
        {
            string idAdelanto = _pocketContext.Adelantos
                            .Select(x => new { IdAdelanto = x.Id })
                            .Max(x => x.IdAdelanto);

            return idAdelanto;
        }

        public Adelanto AddAdelanto(Adelanto adelanto)
        {
            string ultimoId = GetUltimoIdAdelanto();

            if (ultimoId == null)
                adelanto.Id = "00000AAAAA";
            else
                adelanto.Id = NewIdAdelanto(ultimoId);

            adelanto.Fecha = DateTime.Now;
            _pocketContext.Adelantos.Add(adelanto);
            _pocketContext.SaveChanges();

            return adelanto;
        }

        public Adelanto GetAdelanto(string id)
        {
            var adelanto = _pocketContext.Adelantos.Find(id);

            return adelanto;
        }

        public List<Adelanto> GetAdelantos()
        {
            return _pocketContext.Adelantos.ToList();
        }

        public AdelantosNoCancelados GetAdelantosNoCancelados(int legajo)
        {
            var dataset = _pocketContext.Adelantos
                            .Where(x => x.Legajo == legajo && x.Fecha_Cancelacion == null)
                            .Select(x => new AdelantoPagos { Id = x.Id, Legajo = x.Legajo, Monto = x.Monto, Fecha = x.Fecha }).ToList();


            AdelantosNoCancelados adelantosNoCancelados = new AdelantosNoCancelados();
            
            foreach (var item in dataset)
            {
                var datasetPagos = _pocketContext.Pagos
                                    .Where(x => x.Id_Adelanto == item.Id).ToList();

                item.Pagos = datasetPagos;

                decimal montoPagado = _pocketContext.Pagos
                            .Where(x => x.Id_Adelanto == item.Id)
                            .Select(x => new { Monto = x.Monto })
                            .Sum(x => x.Monto);

                item.SaldoDeudor = item.Monto - montoPagado;
            }

            adelantosNoCancelados.Adelantos = dataset;

            return adelantosNoCancelados;
        }

        public Adelanto UpdateFechaCancelacionAdelanto(string idAdelanto)
        {
            var existingAdelanto = _pocketContext.Adelantos.Find(idAdelanto);

            if (existingAdelanto != null)
            {
                existingAdelanto.Fecha_Cancelacion = DateTime.Now;

                _pocketContext.Adelantos.Update(existingAdelanto);
                _pocketContext.SaveChanges();
            }

            return existingAdelanto;
        }

        private string NewIdAdelanto(string id)
        {
            string newId = id;

            string numeros = id.Substring(0, 5);
            string letras = id.Substring(5, 5);

            string l1 = letras.Substring(0, 1);
            string l2 = letras.Substring(1, 1);
            string l3 = letras.Substring(2, 1);
            string l4 = letras.Substring(3, 1);
            string l5 = letras.Substring(4, 1);

            if (l5 == "Z")
            {
                l5 = "A";

                if (l4 == "Z")
                {
                    l4 = "A";

                    if (l3 == "Z")
                    {
                        l3 = "A";

                        if (l2 == "Z")
                        {
                            l2 = "A";

                            if (l1 == "Z")
                            {
                                l1 = "A";

                                int newNumero = Int32.Parse(numeros) + 1;
                                numeros = "00000" + newNumero;
                                numeros = numeros.Substring(numeros.Length - 5, 5);
                            }
                            else
                            {
                                int l1Numero = Encoding.ASCII.GetBytes(l1)[0] + 1;
                                l1 = ((char)l1Numero).ToString();
                            }
                        }
                        else
                        {
                            int l2Numero = Encoding.ASCII.GetBytes(l2)[0] + 1;
                            l2 = ((char)l2Numero).ToString();
                        }
                    }
                    else
                    {
                        int l3Numero = Encoding.ASCII.GetBytes(l3)[0] + 1;
                        l3 = ((char)l3Numero).ToString();
                    }
                }
                else
                {
                    int l4Numero = Encoding.ASCII.GetBytes(l4)[0] + 1;
                    l4 = ((char)l4Numero).ToString();
                }
            }
            else
            {
                int l5Numero = Encoding.ASCII.GetBytes(l5)[0] + 1;
                l5 = ((char)l5Numero).ToString();
            }

            newId = numeros + l1 + l2 + l3 + l4 + l5;

            return newId;
        }

    }
}
