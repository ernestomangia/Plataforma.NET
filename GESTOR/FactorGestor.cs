using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using DTO;
using Modelo;


namespace Gestor
{/*
    public class FactorGestor : IGestor<FactorDTO>, IDisposable
    {
         FactorRepositorio _repositorio;
         Contexto _ctx;
         FactorModelo _factor;

        public FactorGestor()
        {
            try
            {
                _ctx = new Contexto();
                _repositorio= new FactorRepositorio(_ctx);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
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
            }



        }
        
        public void Eliminar(FactorDTO f)
        {
            try
            {
                _factor = _repositorio.GetById(f.Codigo);
                _repositorio.eliminar(_factor);
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);

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
                    _fDTOLista.Add(ModeloaDTO(f));
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
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
            _factor.Proyectos = _factorMod.Proyectos;

        }



        private FactorModelo DTOaModelo(FactorDTO _fDTO)
        {
            var _factor = new FactorModelo();
            _factor.Nombre = _fDTO.Nombre;
            _factor.Codigo = _fDTO.Codigo;
            _factor.Valores = _fDTO.Valores;
            _factor.Proyectos = _fDTO.Proyectos;

            return _factor;
        }

        private FactorDTO ModeloaDTO(FactorModelo _f)
        {
            var _fDTO = new FactorDTO();
            _fDTO.Nombre = _f.Nombre;
            _fDTO.Codigo = _f.Codigo;
            _fDTO.Valores = _f.Valores;
            _fDTO.Proyectos = _f.Proyectos;



        }

    }*/
}
