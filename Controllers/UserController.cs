using Evolve_Game.Context;
using Evolve_Game.Entities;
using Evolve_Game.Request;
using Evolve_Game.Validate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Evolve_Game.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public UserController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRequest request)
        {
            

            ValidationUser validation = new ValidationUser();
            string result = validation.ValidateRegister(request.Email, request.Password, request.Name, _context);
            if(result != "")
            {
                return Ok(result);
            }

            // Criação do User
            User user = new User {
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Gold = 0,
                IdDungeon = 1,
                PosX = 0,
                PosY = 0,
                DateUpdate = request.DateUpdate

            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            PlayerMonsterController pmc = new PlayerMonsterController(_context);
            await pmc.InitRegister(_context.Users.Max(u => u.Id));

            return Ok("Player Salvo com sucesso");
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> LoginUser(LoginRequest request)
        {
            try
            {
                ValidationUser validation = new ValidationUser();
                string result = validation.ValidateLogin(request.Name, request.Password, _context);
                if (result != "")
                {
                    return Ok(result);
                }

               
                User user = _context.Users.Where(p => p.Name == request.Name).Single();
                
                UserResponse userResponse = new UserResponse
                {
                    Name = user.Name,
                    Email = user.Email,
                    Id = user.Id,
                    Gold = user.Gold,
                    IdDungeon = user.IdDungeon,
                    posX = user.PosX,
                    posY = user.PosY,
                    DateUpdate = user.DateUpdate

                };
                user.DateUpdate = request.DateUpdate;
                return Ok(userResponse);

            }
            catch
            {
                return Ok("Erro ao inserir os dados");
            }


        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UserUpdateRequest updateRequest)
        {
            try
            {
              
                User user = await _context.Users.FirstAsync(u => u.Name == updateRequest.Name);
                user.Gold = updateRequest.Gold;
                if (!await _context.Dungeons.AnyAsync(d => d.Id == updateRequest.IdDungeon))
                    return BadRequest("Dungeon Não Encontrada");
                user.IdDungeon = updateRequest.IdDungeon;
                user.PosX = updateRequest.posX;
                user.PosY = updateRequest.posY;

                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Dados do Usuario Alterados com sucesso");

            }
            catch
            {
                return Ok("Erro ao inserir os dados");
            }


        }
        
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string name)
        {
            try
            {
                User user = await _context.Users.FirstAsync(u => u.Name == name);

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Ok("Usuario Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Usuario não encontrada");
            }
        }
    }
}
