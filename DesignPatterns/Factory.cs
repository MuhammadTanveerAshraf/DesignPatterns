using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Factory
    {
        public Factory()
        {
            Console.WriteLine("The Factory method design pattern provides an interface for creating an object but lets the " +
                "subclasses to decide which class to instantiate.");

            List<Document> documents = new()
            {
                new Resume(),
                new Report()
            };

            documents.ForEach(x =>
            {
                Console.WriteLine($"\n {x.GetType().Name} --");
                x.Pages.ForEach(y =>
                {
                    Console.WriteLine(y.GetType().Name);
                });
            });
        }

        //Product
        abstract class Page
        {
        }

        //Concrete Product
        class SkillsPage : Page
        {
        }
        class EducationPage : Page
        {
        }
        class ExperiencePage : Page
        {
        }
        class IntroductionPage : Page
        {
        }
        class ResultPage : Page
        {
        }
        class ConclusionPage : Page
        {
        }
        class SummaryPage : Page
        {
        }
        class BiographyPage : Page
        {
        }

        //Creator
        abstract class Document
        {
            private List<Page> _pages = new List<Page>();

            public Document()
            {
                this.CreatePages();
            }
            public List<Page> Pages
            {
                get { return _pages; }
            }
            public abstract void CreatePages();
        }

        //Concrete Creator
        class Resume : Document
        {
            public override void CreatePages()
            {
                Pages.Add(new SkillsPage());
                Pages.Add(new EducationPage());
                Pages.Add(new ExperiencePage());
            }
        }

        class Report : Document
        {
            public override void CreatePages()
            {
                Pages.Add(new IntroductionPage());
                Pages.Add(new ResultPage());
                Pages.Add(new ConclusionPage());
                Pages.Add(new SummaryPage());
                Pages.Add(new BiographyPage());
            }
        }
    }
}
