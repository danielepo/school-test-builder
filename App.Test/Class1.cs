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
                Title = "Gravidanza e malattie esantematiche",
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

        string test = @"La donna in gravidanza non dovrebbe svolgere attività agonistica:
1.	vero: 1
2.	falso:0

Una donna il cui stato di gravidanza è stato accertato non dovrebbe lavorare:
1.	vero: 0
2.	falso: 1

Una donna in sovrappeso che è in stato di gravidanza non dovrebbe seguire una dieta:
1.	vero: 0
2.	falso:1

Elencami i segni di certezza che stabiliscono lo stato di gravidanza:


Elencami e spiegami brevemente quali sono le funzioni della placenta:
1.	
2.	
3.	
4.	

L’amniocentesi è obbligatoria per le donne oltre i 40 anni?
1.	Vero:0
2.	falso:1

Quali tra queste sono le funzioni del liquido amniotico:
1.	favorisce il parto:1
2.	mantiene costante la temperatura corporea:1
3.	fornisce nutrimento al feto:0
4.	fornisce ossigeno al feto:0

Il cordone ombelicale:
1.	collega la placenta al feto:1
2.	è coperto da uno strato fibroso:0
3.	permette il passaggio dell'ossigeno:1
4.	permette l'eliminazione dell’anidride carbonica:1

Cosa si intende per feto in posizione podalica:

Cosa si intende per travaglio e da quali periodi è costituito:








In quali casi è necessario il parto distocico:
1.	feto in posizione cefalica :0
2.	alterazione del processo fisiologico: 1
3.	sofferenza fetale: 1
4.	bambini di peso superiore a 3Kg: 0

Che cos'è il test di Apgar e in quale momento viene eseguito:





Descrivimi la malattia emolitica neonatale e la sua prevenzione:











La malattia emorragica del neonato:
1.	è più frequente nei nati prematuri:1
2.	è dovuta a carenza di vitamina D: 0
3.	è una patologia con decorso maligno: 0
4.	si risolve entro alcuni giorni: 1

Perché il neonato ha carenza di vitamina K?




Elencami alcune cause che possono provocare asfissia neonatale durante la gravidanza?



Durante il periodo della nascita è possibile che si verifichi asfissia neonatale a causa di:
1.	anomalie placentari:0
2.	aspirazione del liquido amniotico:1
3.	rata eccessiva del parto:1
4.	malattie cardiache della madre:0

È più pericolosa l'asfissia cianotica o l'asfissia bianca?


Mediante quale test viene rilevata una condizione di asfissia neonatale?



Che cos'è la profilassi oculare?




La vitamina K viene somministrata a tutti i neonati:
1.	vero:1
2.	falso:0

Elencami tre dei principali riflessi che vengono rilevati al momento della nascita:
1.	
2.	
3.	

Che cosa si intende per ittero neonatale? In quale caso esso è patologico?



Perché il colostro è importante?



È preferibile l'allattamento al seno anche in caso di parto cesareo?

Che cos'è la lussazione dell’anca? Elencami le cause che possono provocarla.


















L'indagine per la Lussazione congenita dell'anca viene eseguita:
1.	prevalentemente sui nati in posizione podalica:0
2.	Su tutti i neonati:1
3.	prevalentemente sulle femmine:0
4.	nei soggetti considerati a rischio:0

Se la diagnosi di L.C.A. avviene oltre il 5° la terapia posturale con divaricatore sarà poco efficace:
1.	vero:1
2.	falso:0

Che cosa sono le malattie esantematiche?
1.	Patologie infettive:1
2.	comuni negli adulti: 0
3.	malattie per le quali esiste il vaccino: 1
4.	malattie per le quali non è obbligatorio il vaccino:1

Le malattie esantematiche più diffuse sono:
1.	rosolia: 1
2.	parotite:0
3.	varicella:1
4.	scarlatina:0

Il morbillo:
1.	colpisce prevalentemente i bambini al di sotto dei tre anni:1
2.	la contagiosità termina dopo la scomparsa dell'esantema:0
3.	la contagiosità inizia successivamente alla comparsa dell'esantema:0
4.	la vaccinazione è obbligatoria:0

Il vaccino del morbillo è somministrato in un’unica dose:
1.	vero:0
2.	falso:1

Le complicazioni dovute al morbillo sono piuttosto comuni:
1.	vero:0
2.	falso:1

La rosolia è una patologia causata da un batterio:
1.	vero:0
2.	falso:1

Il vaccino per la rosolia è obbligatorio:
1.	vero:0
2.	falso:1

Tra le malattie viste quali sono teratogene?
1.	rosolia: 1
2.	varicella:1
3.	epatite:0
4.	morbillo:0

La terapia specifica per la rosolia si basa sull'assunzione di antibiotici ad ampio spettro.
1.	vero:0
2.	falso:1

La varicella contratta pochi giorni prima del parto non provoca danni per il nascituro:
1.	vero:0
2.	falso:1
Dimmi quali sono le caratteristiche della varicella e qual è la sua terapia:






Se la varicella viene contratta dopo il 4o mese di gravidanza non ci sono conseguenze per il feto:
1.	vero:0
2.	falso:1

Che cos'è il fuoco di Sant'Antonio?



La pertosse:
1.	colpisce prevalentemente bimbi al di sotto dei 2 anni:0
2.	è tramessa per via inalatoria: 1
3.	può portare i lattanti a soffocamento: 1
4.	lascia immunità permanente: 0

La vaccinazione della parotite non esiste:
1.	vero:0
2.	falso:1

La parotite è:
1.	curata con sciroppi per la tosse:0
2.	più pericolosa nei giovani adulti: 1
3.	chiamata anche 'orecchioni':1
4.	contratta per via inalatoria:1

Come si può prevenire la pertosse:


";
    }
}
