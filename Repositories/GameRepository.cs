using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentationApi.Models;

namespace DocumentationApi.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ICompanyRepository _repository;
        private List<Game> games { get; set; }
        public GameRepository(ICompanyRepository repository)
        {
            _repository = repository;
            
            var capcom = _repository.getCompanyByNameAsync("Capcom").Result;

            var easports = _repository.getCompanyByNameAsync("EA-Sports").Result;

            var konami = _repository.getCompanyByNameAsync("Konami").Result;

            games = new List<Game> {
                
                new Game {
                    Id = "5a25a27d-7b5f-42df-b8e7-8e5869f593c1",
                    Name = "Mega-Man",
                    CompanyId = capcom.Id,
                    Company = capcom
                },
                new Game {
                    Id = "504a26af-d4f1-406f-b5b1-87a0b73b0c75",
                    Name = "Resident Evil",
                    CompanyId = capcom.Id,
                    Company = capcom
                },
                new Game {
                    Id = "474e9bf0-850a-472f-ac97-587bee5ec4b5",
                    Name = "Street Fight",
                    CompanyId = capcom.Id,
                    Company = capcom
                },
                new Game {
                    Id = "c39d41ee-c2b3-4a1b-9637-cca503e3692e",
                    Name  = "FIFA",
                    CompanyId = easports.Id,
                    Company = easports
                },
                new Game {
                    Id = "80132b45-6f18-412a-9c62-7aa43fc9b5fd",
                    Name = "Need For Speed",
                    CompanyId = easports.Id,
                    Company = easports
                },
                new Game {
                    Id = "e62ad638-9313-49ba-8a2e-c649341197ad",
                    Name = "Castlevania",
                    CompanyId = konami.Id,
                    Company = konami
                },
                new Game {
                    Id = "c39821df-469a-49da-96dc-853dee1a5e66",
                    Name = "Metal Gear",
                    CompanyId = konami.Id,
                    Company = konami
                },
                new Game {
                    Id = "aa17d313-279c-47ca-b73d-6a13fbfa960d",
                    Name = "Pro Evolution Soccer",
                    CompanyId = konami.Id,
                    Company = konami
                }
            };
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await Task.FromResult(games);
        }

        public async Task<Game> GetGameByIdAsync(string id)
        {
           
            return await Task.FromResult(games.FirstOrDefault(c => c.Id.Equals(id)));
        }

        public async Task<IEnumerable<Game>> GetGamesByCompany(string company)
        {
           return await Task.FromResult(
                games.Where(x => x.Company.Name.ToLower() == company.ToLower()).ToList()
           );
        }
    }
}