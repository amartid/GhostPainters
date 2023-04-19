using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private List<string> lines = new List<string>();
    public float textSpeed;
    private int index;
    private PlayerController playerScript;
    public string speaker="Start";
    public int speakerNumber=0;
    public string popUp;
    // Start is called before the first frame update
    public void Start()
    {   
        SetLines(speaker, speakerNumber);
       // lines.Add()
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(lines.Count !=0 ){
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

    void StartDialogue()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerScript.move=false;
        index = 0;
        Debug.Log("Dialog "+speaker);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if(lines.Count==0){
            playerScript.move=true;
            gameObject.SetActive(false);

        }
        //Type each charachter 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text +=c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(lines.Count==0){
            playerScript.move=true;
            gameObject.SetActive(false);

        }
        if (index < lines.Count-1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            playerScript.move=true;
            gameObject.SetActive(false);
            //PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
            //pop.PopUp(popUp); //to display a popup box for more information
        }
        
    }
    //========================================================
    private static string[] vincent = {
        "Είμαι ο Βίνσεντ βαν Γκογκ(Vincent Willem van Gogh),", 
        "έζησα μεταξύ του 1853-1890 και ήμουν Ολλανδός.",
        "Συμμετείχα στα κινήματα του μεταϊμπρεσιονισμού και εξπρεσιονισμού.", 
        "Χρησιμοποιούσα μια τεχνική στροβιλισμάτων(κυκλικές κινήσεις) με το πινέλο,",
        "και τα χρώματα που κυριαρχούν στα έργα μου είναι κίτρινο πράσινο και μπλε.",
        "Δύο από τα σημαντικότερα έργα μου είναι ένα «πορτρέτο του εαυτού μου» - 1887 και η «Έναστρη Νύχτα» - 1889."
    };
    private static string[] jackson = {
        "Είμαι ο Τζάκσον Πόλοκ (Paul Jackson Pollock), ",
        "έζησα μεταξύ του 1912-1956 και ήμουν Αμερικανός.",
        "Συμμετείχα στο κίνημα του αφηρημένου εξπρεσιονισμού.",
        "Εφηύρα την «τεχνική της σταγόνας», να ρίχνω ή να πιτσιλάω υγρό χρώμα σε μια οριζόντια επιφάνεια.",
        "Τα έργα μου δηλαδή είναι πολύχρωμα σε όλη την επιφάνεια τους.",
        "Δύο από τα σημαντικότερα έργα μου είναι τα «Number 17A» - 1948 και «No. 5» - 1948 δεν έχουν ιδιαίτερες ονομασίες γιατί είναι αφηρημένα !"
    };
    private static string[] pablo = {
        "Είμαι ο Πάμπλο Πικάσο (Pablo Ruiz Picasso), ",
        "έζησα μεταξύ του 1881-1973 και ήμουν Ισπανός.",
        "Συμμετείχα στο κίνημα του κυβισμού και του σουρεαλισμού.",
        "Καθώς, διαμόρφωσα και εξέλιξη της μοντέρνας και σύγχρονης τέχνης.",
        "Δύο από τα σημαντικότερα έργα μου είναι o πίνακας «Γκερνίκα» - 1937 και «Η γυναίκα που κλαίει» - 1937."
    };
    private static string[] leonardo = {
        "Είμαι ο Λεονάρντο ντα Βίντσι (Leonardo da Vinci), ",
        "έζησα μεταξύ του 1452 – 1519 και ήμουν Ιταλός.",
        "Ήμουν πολυμαθής της Ύστερης Αναγέννησης. ",
        "Τα έργα μου ήταν κυρίως ρεαλιστικά.",
        "Είχα σημειώσεις που αφορούσαν την ανατομία, την χαρτογραφία, την ζωγραφική, την παλαιοντολογία και διάφορες επιστημονικές εφευρέσεις.",
        "Δύο από τα σημαντικότερα έργα μου είναι η «Μόνα Λίζα» - 1503-1506 και «Ο Μυστικός Δείπνος» - 1492–1498."
    };
    private static string[] andy = {
        "Είμαι ο Άντι Γουόρχολ (Andy Warhol), ",
        "έζησα μεταξύ του 1928 – 1987 και ήμουν Αμερικανός.",
        "Ήμουν πολυσχιδής καλλιτέχνης, ζωγράφος, γλύπτης, κινηματογραφιστής, συγγραφέας και συλλέκτης",
        "Ήμουν πρωτοπόρος του κινήματος της Ποπ Αρτ.",
        "Χρησιμοποίησα μια τεχνική ιχνογραφίας για να παράγω μια σειρά από πανομοιότυπες εικόνες.",
        "Δύο από τα σημαντικότερα έργα μου είναι η «Κονσέρβες σούπας Campbell» - 1961 - 1962 και ο «Μέριλιν Δίπτυχο» - 1962.", 
        "Όπως θα δεις είναι πολλές αποτυπώσεις πανομοιότυπων εικόνων."
    };
    private static string[] wassily = {
        "Είμαι ο Βασίλι Καντίνσκι (Wassily Kandinsky), ",
        "έζησα μεταξύ του 1866-1944 και ήμουν Ρώσος.",
        "Συμμετείχα στο κίνημα της αφηρημένης τέχνης.",
        "Πίστευα ότι ο τρόπος με τον οποίο τα χρώματα και οι γραμμές τοποθετούνται σε ένα πίνακα εκφράζουν δυνατά συναισθήματα.",
        "Ανακάτευα τεχνικές και αποχρώσεις ζωγραφικής χρησιμοποιούσα έντονα χρώματα και αντιθέσεις.",
        "Δύο από τα σημαντικότερα έργα μου είναι o «Γαλάζιος Καβαλάρης» - 1903 και «Στο Λευκό II» - 1923,",
        "όπου φαίνεται έντονα η μετάβαση μου στην αφηρημένη τέχνη από το ένα έργο στο άλλο."
    };
    //========================================================
    private static string[] vincentItem1 = {
        "Εν ζωή αντιμετώπιζα ψυχικά προβλήματα και αναζητώντας λύση..",
        "..έκοψα το αυτί μου!",
    };
    private static string[] vincentItem2 = {
        "Είχα κακίες συνήθειες κάπνιζα, έπινα αλκοόλ και έκανα και κακή διατροφή. Η αιτία του θανάτου μου ήταν αυτοκτονία...",
        "Η σωστή διατροφή είναι υγεία!",
    };
    private static string[] jacksonItem = {
        "Έπασχα από κατάθλιψη, ήμουν αλκοολικός και η αιτία του θανάτου μου ήταν τροχαίο ατύχημα. Να αποφεύγεις το πολύ αλκοόλ!"
    };
    private static string[] pabloItem = {
        "Έλεγα πάντα ότι, η ζωγραφική είναι απλώς ένας άλλος τρόπος να κρατάς ημερολόγιο. .",
        "Έχοντας αυτή τη νοοτροπία μπορείτε να γίνετε μια καλύτερη εκδοχή του δημιουργικού σας εαυτού."
        //"Πέθανα από φυσικά αίτια."
    };
    private static string[] leonardoItem = {
        "Έχανα εύκολα την ψυχραιμία μου... Φρόντισε να είσαι υπομονετικός"
        //"και η αιτία του θανάτου μου ήταν καρκίνος του πνεύμονα.",
    };
    private static string[] andyItem = {
        "Οι συλλογές έργων  που είχα  και κοσμημάτων διακοσμητικής ή λαϊκής τέχνης δημοπρατήθηκαν."
    };
    private static string[] wassilyItem = {
        "Πίστευα ότι η μουσική έχει μια σχέση με τη ζωγραφική",
        "Το χρώμα είναι μια δύναμη που επηρεάζει άμεσα την ψυχή. Το χρώμα είναι το πλήκτρα, τα μάτια είναι τα σφυράκια, η ψυχή είναι το πιάνο με τις χορδές.",
        "Ο καλλιτέχνης είναι το χέρι που παίζει, αγγίζοντας το ένα ή το άλλο πλήκτρο, για να προκαλέσει τις δονήσεις στην ψυχή",
        "Πολλά έργα μου καταστράφηκαν από το ναζιστικό καθεστώς. "
    };
    //========================================================
    private static string[] start = {
        "Καλωσόρισες, πάτησε το SPACE για συνεχίσεις!",
        "Κινήσου με τα πλήκτρα W, A, S, D ή με τα βέλη.",
        "Το Μουσείο στοιχειώνουν φαντάσματα ζωγράφων του παρελθόντος.",
        "Μίλα μαζί τους για να μάθεις για τη ζωή, το έργο τους καθώς και τα κινήματα της τέχνης στα οποία συμμετείχαν.",
        "Πάτησε το SPACE για μιλήσεις σε κάποιο ή να ερευνήσεις τα αντικείμενα των δωματίων!",
        "Περιηγήσου στα δωμάτια και κοίτα τους πίνακες προσεκτικά.",
        "Σε κάθε δωμάτιο υπάρχουν δύο πίνακες ενός ζωγράφου.",
        "Τα φαντάσματα έχουν χαθεί...! Μπορείς να τα βοηθήσεις;",
        "Πάτησε το πλήκτρο LEFT SHIFT ώστε σε ακολουθήσει κάποιο ή ώστε να σταματήσει να σε ακολουθεί.",
        "Πάρε τη σωστή απόφαση και....Οδήγησε το κάθε φάντασμα στο δωμάτιο με τα έγα του!",
        "Καλή επιτυχία ! ! !"
    };
    private static string[] win = {
        "Συγχαρητήρια ! ! !",
        "Οδήγησες τα φαντάσματα στα σωστά δωμάτια.",
        "Τα φαντάσματα έφυγαν και το Μουσείο είναι πλέον ανοιχτό!"
    };
    private static string[] notwin = {
        "Δυστυχώς δεν κατάφερες να οδηγήσεις τα φαντάσματα στα σωστά δωμάτια...",
        "Για αυτό συνεχίζουν να στοιχειώνουν το Μουσείο !",
        "Δοκίμασε ξανά ! ! ! "
    };
    //========================================================
    public void AddManyLines(string[] linesArray)
    {
        lines.Clear();
        foreach (string l in linesArray){
            lines.Add(l);
        } 
    }

    public void SetLines(string painterName, int number)
    {
        switch(painterName) 
        {
            case "Start":
                AddManyLines(start);
                break;
            case "Win":
                AddManyLines(win);
                break;
            case "Not Win":
                AddManyLines(notwin);
                break;
            case "Van Gogh":
                AddManyLines(vincent);
                break;
            case "Pollock":
                AddManyLines(jackson);
                break;
            case "Picasso":
                AddManyLines(pablo);
                break;
            case "Da Vinci":
                AddManyLines(leonardo);
                break;
            case "Andy Warhol":
                AddManyLines(andy);
                break;
            case "Kandinsky":
                AddManyLines(wassily);
                break;
            case "Van item 1":
                AddManyLines(vincentItem1);
                break;
            case "Van item 2":
                AddManyLines(vincentItem2);
                break;
            case "Pollock item":
                AddManyLines(jacksonItem);
                break;
            case "Picasso item":
                AddManyLines(pabloItem);
                break;
            case "Da Vinci item":
                AddManyLines(leonardoItem);
                break;
            case "Andy Warhol item":
                AddManyLines(andyItem);
                break;
            case "Kandinsky item":
                AddManyLines(wassilyItem);
                break;
            default:
                {
                    lines.Add("");
                    index=1;
                }
                break;
        }
    }
}
