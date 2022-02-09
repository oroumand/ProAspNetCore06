using EfIntro.Models;

Repository _repository = new Repository();
_repository.Delete(3);
_repository.PrintPeople();

Console.ReadLine();
