using System;
using System.Collections.Generic;
using System.Linq;

using AccesoDatos;
using DTO;
using Modelo;
using Repositorio;

namespace Gestor
{
    public class FactorGestor : IGestor<FactorDTO>, IDisposable
    {
        private FactorRepositorio _repositorio;
        private Contexto _ctx;
        private FactorModelo _factor;

        public FactorGestor()
        {
            try
            {
                _ctx = new Contexto();
                _repositorio = new FactorRepositorio(_ctx);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }

        public void Guardar(FactorDTO f)
        {
            try
            {
                if (f.Codigo > 0)
                {
                    FactorModelo _factorMod = DTOaModelo(f);
                    _factor = _repositorio.GetById(f.Codigo);
                    this.ActualizaFactor(_factorMod);
                }
                else
                {
                    _factor = DTOaModelo(f);
                }
                _repositorio.Guardar(_factor, _factor.Codigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }

        public void Eliminar(FactorDTO f)
        {
            try
            {
                _factor = _repositorio.GetById(f.Codigo);
                _repositorio.Eliminar(_factor);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }

        public FactorDTO GetById(int id)
        {
            FactorDTO _fDTO = new FactorDTO();

            try
            {
                _fDTO = ModeloaDTO(_repositorio.GetById(id));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw ex;
            }

            return _fDTO;
        }

        public IList<FactorDTO> Listar()
        {
            IList<FactorDTO> factorDTOLista = new List<FactorDTO>();

            try
            {
                var fLista = _repositorio.Listar();

                foreach (var f in fLista)
                {
                    factorDTOLista.Add(this.ModeloaDTO(f));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw ex;
            }
            return factorDTOLista;
        }

        public bool Validar(FactorDTO entidad)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #region Private Methods

        private void ActualizaFactor(FactorModelo factorMod)
        {
            _factor.Nombre = factorMod.Nombre;
            _factor.Valores[0].Nombre = factorMod.Valores[0].Nombre;
            _factor.Valores[1].Nombre = factorMod.Valores[1].Nombre;
            _factor.Valores[2].Nombre = factorMod.Valores[2].Nombre;
        }

        private FactorModelo DTOaModelo(FactorDTO fDTO)
        {
            var factor = new FactorModelo
                             {
                                 Nombre = fDTO.Nombre,
                                 Codigo = fDTO.Codigo,
                                 Proyectos = fDTO.Proyectos
                             };

            factor.Valores.AddRange(
                fDTO.ValoresFactores.Select(
                    item => new ValorFactorModelo
                                {
                                    Codigo = item.Codigo,
                                    Nombre = item.Nombre,
                                    Valor = item.Valor
                                }));

            return factor;
        }

        private FactorDTO ModeloaDTO(FactorModelo factorModelo)
        {
            var fDTO = new FactorDTO
                           {
                               Codigo = factorModelo.Codigo,
                               Nombre = factorModelo.Nombre
                           };

            fDTO.ValoresFactores.AddRange(
                factorModelo.Valores.Select(
                    item =>
                    new ValorFactorDTO
                        {
                            Codigo = item.Codigo,
                            Nombre = item.Nombre,
                            Valor = item.Valor
                        }));

            fDTO.Proyectos = factorModelo.Proyectos;

            return fDTO;
        }

        #endregion
    }
}
