using Microsoft.AspNetCore.Mvc;
using RedBrowBackend.GenericClasses;
using RedBrowBackend.Models;
using RedBrowBackend.Services;

namespace RedBrowBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService) 
        {
            _usersService = usersService;
        }

        // GET: api/Users/paginated
        /// <summary>
        /// Obtiene un resultado paginado del objeto Users de la BD.
        /// </summary>
        /// <param name="orden">Nombre de campo por el cual ordenar (distingue mayúsculas).</param>
        /// <param name="tipo_orden">Tipo de orden: ASC (ascendente) / DESC (descendente).</param>
        /// <param name="pagina">Número de página a obtener.</param>
        /// <param name="registros_por_pagina">Número de registros por página.</param>
        /// <returns></returns>
        [HttpGet("paginated")]
        public async Task<ActionResult<GenericPager<Users>>> GetAllUsersP(string orden = "Id",
                                                                          string tipo_orden = "DESC",
                                                                          int pagina = 1,
                                                                          int registros_por_pagina = 10)
        {
            List<Users> _users;
            GenericPager<Users> _GenericPagerUsers;
            _users = await _usersService.GetAllUsers();

            // ORDENACIÓN POR COLUMNAS
            switch (orden)
            {
                case "Id":
                    if (tipo_orden.ToLower() == "desc")
                    _users = _users.OrderByDescending(u => u.Id).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _users = _users.OrderBy(x => x.Id).ToList();
                    break;
            }

            // PAGINACIÓN
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            // Número total de registros de la tabla Users
            _TotalRegistros = _users.Count();
            // Obtenemos la 'página de registros' de la tabla Users
            _users = _users.Skip((pagina - 1) * registros_por_pagina)
                                             .Take(registros_por_pagina)
                                             .ToList();
            // Número total de páginas de la tabla Users
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);

            // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _GenericPagerUsers = new GenericPager<Users>()
            {
                RecordsPerPage = registros_por_pagina,
                TotalRecords = _TotalRegistros,
                TotalPages = _TotalPaginas,
                ActualPage = pagina,
                CurrentOrder = orden,
                CurrentOrderType = tipo_orden,
                Result = _users
            };

            if (_GenericPagerUsers == null)
            {
                return NotFound("User Not Found.");
            }
            else { return Ok(_GenericPagerUsers); }
        }

        // GET: api/Users
        /// <summary>
        /// Obtiene todos los daots del objeto Users de la BD.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAllUsers() 
        {
            return await _usersService.GetAllUsers();
        }

        // GET: api/Users
        /// <summary>
        /// Obtiene un solo resultado del objeto Users de la BD.
        /// </summary>
        /// <param name="id">Id del usuario por el cual buscaremos</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetSingleUser(int id)
        {
            var User = await _usersService.GetSingleUser(id);
            if (User == null)
            {
                return NotFound("User Not Found.");
            }
            else { return Ok(User); }
        }

        // GET: api/Users
        /// <summary>
        /// Obtiene un solo resultado del objeto Users de la BD.
        /// </summary>
        /// <param name="user">Objeto Usuario que agregaremos a la BD</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<Users>>> AddUser(Users user)
        {
            var result = await _usersService.AddUser(user);
            return Ok(result);
        }

        // GET: api/Users
        /// <summary>
        /// Obtiene un solo resultado del objeto Users de la BD.
        /// </summary>
        /// <param name="id">Id del usuario por el cual buscaremos</param>
        /// <param name="user">Objeto Usuario que Modificaremos en la BD</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<List<Users>>> UpdateUser(int id, Users user)
        {
            var result = await _usersService.UpdateUser(id, user);
            if (result == null)
            {
                return NotFound("User Not Found.");
            }
            else { return Ok(result); }
        }

        // GET: api/Users
        /// <summary>
        /// Obtiene un solo resultado del objeto Users de la BD.
        /// </summary>
        /// <param name="id">Id del usuario por el cual buscaremos</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<List<Users>>> DeleteUser(int id)
        {
            var result = await _usersService.DeleteUser(id);
            if (result == null)
            {
                return NotFound("User Not Found.");
            }
            else { return Ok(result); }
        }
    }
}
