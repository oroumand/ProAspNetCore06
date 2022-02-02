using Microsoft.EntityFrameworkCore;
using SimpleEfConficurationSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.DAL;
public class NewsRepository
{
    private readonly ConfigSampleContext _context;

    public NewsRepository(ConfigSampleContext context)
    {
        _context = context;
    }

    public void Remove(int removeBy,int id)
    {
        var news = _context.News.FirstOrDefault(c=>c.NewsId == id);
        if(news != null)
        {
            _context.Entry(news).Property<int>("DeleteBy").CurrentValue = removeBy;
            _context.Entry(news).Property<bool>("IsDeleted").CurrentValue = true;
        }
    }

    public News GetNews(int Id)
    {
        return _context.News.FirstOrDefault(c => EF.Property<bool>(c, "IsDeleted") == false && c.NewsId == Id);
    }
}
