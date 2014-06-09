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
                    this.ActualizaFactor(_factorMod, _factor);
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
            IList<FactorDTO> _fDTOLista = new List<FactorDTO>();

            try
            {
                IQueryable<FactorModelo> _fLista = _repositorio.Listar();

                foreach (FactorModelo f in _fLista)
                {
                    _fDTOLista.Add(this.ModeloaDTO(f));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw ex;
            }
            return _fDTOLista;
        }

        public bool Validar(FactorDTO entidad)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private void ActualizaFactor(FactorModelo _factorMod, FactorModelo _factor)
        {
            _factor.Codigo = _factorMod.Codigo;
            _factor.Nombre = _factorMod.Nombre;
            _factor.Valores = _factorMod.Valores;
            //_factor.Proyectos = _factorMod.Proyectos;
        }

        private FactorModelo DTOaModelo(FactorDTO _fDTO)
        {
            var factor = new FactorModelo();
            factor.Nombre = _fDTO.Nombre;
            factor.Codigo = _fDTO.Codigo;
            factor.Valores = _fDTO.Valores;
            factor.Proyectos = _fDTO.Proyectos;

            return factor;
        }

        private FactorDTO ModeloaDTO(FactorModelo _f)
        {
            var fDTO = new FactorDTO();
            fDTO.Nombre = _f.Nombre;
            fDTO.Codigo = _f.Codigo;
            fDTO.Valores = _f.Valores;
            fDTO.Proyectos = _f.Proyectos;
            
            return fDTO;
        }
    }
}
