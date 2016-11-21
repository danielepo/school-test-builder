using BL;
using Entities;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Test
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            var parser = new QuestionParser();
            var generator = new ExamGenerator();
            var documenter = new DocumentGenerator();
            var questions = parser.Parse(test);
            var exam = new Exam()
            {
                Title = "Educazione alimentare",
                Questions = questions,
                Instructions = "Leggere attentamente le domande e fare una X su una o più risposte per indicare quelle corrette. Oppure completa le parti mancanti dove opportuno."
            };
            var exams = generator.Create(exam, 20);
            foreach (var e in exams)
                documenter.Create(e);

            var answers = new AnswerExtractor().Extract(exams);
            new AnswerSheetWriter().Create(answers);
        }
        string test = @"Il metabolismo basale è:
1.	La quantità minima di energia consumata da un soggetto in condizioni di riposo: 1
2.	La quantità di calorie giornaliere: 0
3.	La quantità di energia necessaria allo svolgimento delle attività: 0
4.	La quantità di energia che una persona di media statura consuma in un giorno: 0

Metabolismo totale è la somma di:

Le reazioni anaboliche sono reazioni che sintetizzano nuove molecole
1.	VERO: 1
2.	FALSO: 0

Le reazioni cataboliche sono reazioni che producono energia.
1.	VERO: 1
2.	FALSO: 0

Mediante reazioni cataboliche si formano nuove molecole:
1.	VERO: 0
2.	FALSO: 1


Dopo digestione di protidi cosa ottengo?
1.	Amminoacidi: 1
2.	Glucosio ed altri zuccheri semplici: 0
3.	Acidi grassi e glicerolo: 0

I glucidi sono:
1.	Zuccheri: 1
2.	Grassi: 0
3.	Proteine: 0
4.	Carboidrati: 1

Dimmi quali sono le 3 funzioni delle proteine:

Proteine ad alto valore biologico sono contenute nel:
1.	Pesce: 1
2.	Carne: 1
3.	Pasta: 0

Le proteine ad alto valore biologico hanno tutti gli 8 amminoacidi essenziali
1.	VERO: 1
2.	FALSO: 0

Le proteine ad alto valore biologico hanno tutti e 10 gli amminoacidi essenziali:
1.	VERO: 0
2.	FALSO: 1

Con quale alimento posso integrare la pasta per ottenere quel pool di amminoacidi essenziali che costituiscono una proteina nobile?
1.	Piselli: 1
2.	Fagioli: 1
3.	Carote: 0

L'apporto calorico di 1g di proteine è di
L'apporto calorico di 1g di glucidi è di
L'apporto calorico di 1g di grassi è di

La percentuale di proteine ingerite giornalmente dovrebbe essere il 50-60% del totale delle calorie fornite con la dieta.
1.	VERO: 0
2.	FALSO: 1

La carenza proteica:
1.	Non esiste: 0
2.	È più comune nei Paesi poveri: 1
3.	Si manifesta con ventre gonfio, alterazioni della pigmentazione della cute e dei capelli.... :1

Eccedere con i carboidrati può essere dannoso? A cosa può portare?

La gotta è causata da:
1.	Eccessiva ingestione di proteine: 1
2.	Eccessiva assunzione di acqua: 0
3.	Scarsa assunzione di vitamine: 0

Il malato di gotta deve seguire una terapia farmacologica o è sufficiente segua una dieta adeguata?

Il malato di gotta può assumere carne?

Elencami 2 alimenti che il malato di gotta non può assumere:

Gli zuccheri si dividono in:
1.	monosaccaridi:1
2.	
3.	

Dimmi due dei tre monosaccaridi che conosci
1.	
2.	
 
Dimmi due dei tre disaccaridi che conosci
1.	
2.	
 
Dimmi dov'è contenuto il galattosio:

Il lattosio è un disaccaride?
1.	VERO: 1
2.	FALSO: 0

Il saccarosio è un monosaccaride?
1.	VERO: 0
2.	FALSO: 1

Il glucagone è:
1.	Un enzima: 0
2.	Un ormone: 1
3.	Un polisaccaride: 0

L'insulina è prodotta dal:
1.	Fegato: 0
2.	Pancreas: 1
3.	Cuore: 0

L'insulina viene prodotta da
1.	Cellule alfa del pancreas: 0
2.	Cellule beta del pancreas: 1
3.	Cellule beta del fegato: 0

L'insulina fa abbassare la glicemia nel sangue
1.	VERO: 1
2.	FALSO: 0

L'insulina viene prodotta quando c'è poco zucchero nel sangue:
1.	VERO: 0
2.	FALSO: 1

L'iperglicemia è causata da:
1.	Eccessivo consumo di zuccheri: 1
2.	Scarsa assunzione di proteine: 0
3.	Eccessivo consumo di grassi: 0

Il glucagone è prodotto in situazioni di ipoglicemia:
1.	VERO: 1
2.	FALSO: 0

Il glucagone:
1.	Non esiste: 0
2.	è prodotto dalle cellule alfa del pancreas: 1
3.	è prodotto dalle cellule beta del pancreas: 0


L'iperglicemia è una situazione caratteristica nel diabete mellito.
1.	VERO: 1
2.	FALSO: 0

In caso di diabete mellito che alimenti si devono evitare?
1.	Torte:1
2.	Gelati: 1
3.	Verdure:0
4.	Proteine: 0

Si verifica spesso carenza glucidica? Spiega il perché
1.	Sì: 0
2.	No: 1



I grassi insaturi si trovano in buona quantità in:
1.	pesce: 1
2.	burro: 0
3.	formaggio: 0
4.	olii vegetali: 1

Chi soffre di ipercolesteroleia non deve assumere grassi
1.	VERO: 0
2.	FALSO:1

Chi soffre di ipercolesteroleia deve ridurre i grassi
1.	VERO: 1
2.	FALSO: 0

Cosa sono gli ω3?
1.	Acidi grassi essenziali: 1
2.	Acidi grassi con doppio legame: 1
3.	Acidi grassi insaturi: 1

Cosa sono gli ω6?
1.	Acidi grassi essenziali: 1
2.	Proteine: 0
3.	Acidi grassi saturi: 0
4.	Acidi grassi insaturi: 1


Avere l'HDL elevato è un fattore positivo?
1.	VERO: 1
2.	FALSO: 0


Trova la vitamina che non fa parte di quelle liposolubili
1.	A: 0
2.	C: 1
3.	K: 0
4.	E: 0
Elenca le vitamine liposolubili

Quali sono le 3 principali fonti della vitamina A

Cosa provoca carenza di vitamina A:
1.	Osteomalacia: 0
2.	Trombosi: 0
3.	Disturbi a carico dell'occhio: 1
4.	Alterazione degli epiteli: 1

La vitamina B12 è presente in:
1.	Alimenti vegetali: 0
2.	Alimenti di origine animale: 1

I vegetariani non hanno carenza di vitamina B12 perché gli ortaggi ne sono ricchi:
1.	VERO: 0
2.	FALSO:1

L'anemia perniciosa è dovuta a:
1.	Eccesso di vitamina B12: 0
2.	Carenza di vitamina B12: 1
3.	Incapacità di assorbire la vitamina B12 a livello intestinale: 1

Che cos'è la pellagra:
1.	Una malattia: 1
2.	Una malattia che non esiste più: 0
3.	Una malattia dovuta a carenza di vitamina B9: 0

Il fruttosio si trova solo nel miele:
1.	VERO: 0
2.	FALSO:1

Che funzioni hanno i glucidi?

Che cosa sono le tabelle LARN:




Quale vitamina non fa parte di quelle idrosolubili:
1.	PP: 0
2.	B: 0
3.	K: 1

Quale altro nome ha la vitamina C

Una carenza di vitamina D cosa provoca?
1.	Rachitismo nei bimbi: 1
2.	Perdita di peso: 0
3.	Colorito spento: 0

Dimmi 2 alimenti in cui è contenuta la vitamina K?
1.	 
2.	 

La vitamina K è introdotta solo con l'alimentazione
1.	VERO: 0
2.	FALSO: 1

La carenza di vitamina E può portare a                    .

La vitamina C viene distrutta col calore
1.	VERO: 1
2.	FALSO: 0

Assumendo troppe vitamine del gruppo B posso andare incontro a problemi di accumulo
1.	VERO: 0
2.	FALSO: 1
";
    }
}
