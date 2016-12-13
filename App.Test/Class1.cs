using BL;
using Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Test
{
    class DaRimuovereAPpenaAbbiamoGenerazioneEsameFunzionanteDaWeb
    {

        [Test]
        [Ignore("Non è un vero test, serve a generare un esame")]
        public void TestMethod()
        {
            var parser = new QuestionParser();
            var generator = new ExamGenerator();
            var documenter = new DocumentGenerator();
            var questions = parser.Parse(test);
            var exam = new Exam()
            {
                Title = "Sistema scheletrico",
                Instructions = "Leggere attentamente le domande e fare una X su una o più risposte per indicare quelle corrette. Oppure completa le parti mancanti dove opportuno."
            };
            foreach (var q in questions)
            {
                exam.Insert(q);
            }
            var exams = generator.Create(exam, 4);
            foreach (var e in exams)
                documenter.Create(e);
            var answers = new AnswerExtractor().Extract(exams);
            new AnswerSheetWriter().Create(answers);
        }

        string test = @"Quale dei seguenti metodi contraccettivi non è naturale:
1.	Metodo Billings
2.	Il diaframma:1
3.	La temperatura basale
La pillola del giorno dopo è un metodo contracettivo
1.	Vero
2.	Falso:1
Quanti denti da latte ha un bambino
1.	22
2.	20:1
3.	10
Ci si deve lavare i denti:
1.	Ogni volta che mangiamo
2.	All’occorrenza
3.	3 volte al giorno:1
La membrana plasmatica è:
1.	L’involucro esterno della cellula:1
2.	Costituita da fosfolipidi:1
3.	Immersa nel citoplasma
Le cellule sono grandi 1 mm
1.	Vero
2.	Falso:1
Dimmi la funzione dei lisosomi:
Dimmi cosa sono i ribosomi
I ribosomi:
1.	Digeriscono particelle
2.	Rappresentano la centrale energetica della cellula
3.	Sintetizzano le proteine:1
L’apparato del Golgi:
1.	Sintetizza molecole di carboidrati:1
2.	Sintetizza proteine
3.	Digerisce particelle
La membrana plasmatica è
1.	Una barriera impermeabile
2.	È selettivamente permeabile:1
3.	Permette il trasporto passivo:1
La fagocitosi è
1.	Una forma di trasporto passivo
2.	Una forma di trasporto attivo:1
3.	Un meccanismo di osmosi
Il nucleo plasma:
1.	È il nucleo della cellula
2.	È un fluido gelatinoso:1
3.	È un fluido in cui è presente la cromatina:1
La cromatina è costituita da solo DNA:
1.	Vero
2.	Falso:1
Le cellule somatiche hanno 23 cromosomi
1.	Vero
2.	Falso:1
Le cellule aploidi sono cellule sessuali
1.	Sono cellule sessuali:1
2.	Hanno solo 23 cromosomi
3.	Sono cellule anomale
Fammi un esempio di epitelio squamoso semplice:
Il tessuto adiposo è un tessuto connettivo:
1.	Vero:1
2.	Falso
Dimmi la funzione del tessuto emopoietico
La nevroglia:
1.	È una cellula molto grande che si trova a livello renale
2.	Un tessuto che provvede al nutrimento dei neuroni:1
3.	Un tessuto che provvede al sostegno dei neuroni:1
Il tessuto muscolare cardiaco
1.	È un tessuto connettivo
2.	Ha una contrazione involontaria:1
3.	Costituisce le pareti del cuore:1
Il tessuto muscolare scheletrico
1.	Forma i muscoli volontari:1
2.	La sua contrazione è involontaria
3.	Viene classificato come liscio
Fammi un esempio di organi accessori
Elencami i 5 strati dell’epidermide – 2 punti
1.
2.
3.
4.
5.
Le funzioni della cute sono:
1.	Protezione:1
2.	Sintesi della vitamina A
3.	Termoregolazione
Una persona abbronzata non ha bisogno di usare la protezione solare
1.	Vero
2.	Falso:1
Le ghiandole sudoripare:
1.	Sono ghiandole endocrine
2.	Producono il sebo
3.	Si trovano nella parte profonda del derma:1
Le ghiandole sebacee sono:
1.	Ghiandole esocrine:1
2.	Difendono la pelle dall’umidità:1
3.	Gli uomini ne hanno poche
Dimmi due elementi che favoriscono l’invecchiamento cutaneo
1.
2.
L’apparato locomotore è costituito da
1.	Sistema scheletrico:1
2.	Sistema muscolare:1
3.	Sistema cardiaco
4.	Sistema emuntore
Le ossa hanno funzione:
1.	Di deposito minerale:1
2.	Protettiva:1
3.	Emopoietica:1
Alla nascita il midollo osseo appartiene totalmente alla tipologia gialla
1.	Vero
2.	Falso:1
Le ossa nell’adulto sono:
1.	178
2.	206:1
3.	216
4.	Dipende dall’età
Che cos'è l'osteoporosi:
L'osteomalacia è
1.	uno sviluppo anomalo dello scheletro:1
2.	dovuto ad eccesso di vitamina D
3.	è una patologia del bambino
Dimmi le principali differenze tra artrosi ed artrite




La gotta:
1.	è dovuta ad eccessivo consumo di carne:1
2.	causa dolore a livello delle giunture:1
3.	causa eccessivo accumulo di acido urico:1
Il ginocchio può effettuare soprattutto movimenti:
1.	di flessione:1
2.	estensione: 1
3.	torsione
I menischi sono due ossa:
1.	vero
2.	falso:1
La rotula è un osso:
1.	vero:1
2.	falso
Le ossa che compongono lo scheletro sono collegate tra loro mediante:
1.	tendini
2.	articolazioni
3.	legamenti:1
Dimmi funzione principale dei legamenti

Fammi un esempio di articolazione immobile
Fammi un esempio di articolazione mobile
Fammi un esempio di articolazione semimobile
Lo scheletrico dell'arto superiore è formato da:
1.	omero- radio-ulna+ ossa mano:1
2.	omero-ulna-radio
3.	omero-ulna-perone
Lo scheletrico della gamba è formato da
1.	omero-ulna perone
2.	femore-tibia-perone:1
3.	femore-metacarpo-rotula
Dimmi qual è l'osso più lungo del corpo umano
Lo scheletro del piede è costituito da carpo metacarpo e le falangi
1.	vero
2.	falso:1
L'osso iliaco è formato da tre ossa quali?
Il cinto scapolare è formato da:
La gabbia toracica permette di:
1.	proteggere il cuore:1
2.	proteggere i polmoni:1
3.	respirare: 1
Elencami le ossa della faccia
Dimmi qual è l'unico osso mobile del cranio:
Dimmi qual è l'unico osso del corpo che non presenta articolazioni con altre ossa:
La scogliosi può essere curata:
1.	mediante ginnastica agonistica
2.	uso di corsetti:1
3.	massaggi
4.	interventi chirurgici:1
L'ernia al disco deriva da:
1.	una postura errata
2.	scivolamento di un disco intervertebrale:1
3.	compressione del midollo spinale:1
4.	l'uso di droghe
Lo scheletro del cranio comprende:
1.	le ossa della faccia:1
2.	le ossa del neurocranio:1";
    }
}
