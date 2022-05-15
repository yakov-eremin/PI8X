package com.example.bdd;

import java.util.HashSet;
import java.util.Set;

public class Therapist {
    private final String questionAboutLeukocytes = "Количество лейкоцитов в ОАК?";
    private final String questionAboutThroat = "Горло в волдырях?";
    Set<String> symptoms = new HashSet<>();
    String currentQuestion;

    public void tellTherapistAboutSymptom(String symptom){
        symptoms.add(symptom);
    }

    public Answer ask(){
        if(symptoms.contains("высокая температура")){
            if((symptoms.contains("сухой кашель") || symptoms.contains("мокрый кашель"))){
                if(symptoms.contains("гиперлейкоцитоз")){
                    if(symptoms.contains("мокрый кашель"))
                        return new Answer(true, "ОРЗ, Лечение: антибиотики широкого спектра и АЦЦ");
                    else
                        return new Answer(true, "ОРЗ, Лечение: антибиотики широкого спектра");
                }
                else if(symptoms.contains("лейкоциты в норме")){
                    return new Answer(true, "ОРВИ, Лечение: лекраства не требуются, пить больше воды");
                }
                else {
                    currentQuestion = questionAboutLeukocytes;
                    return new Answer(false, questionAboutLeukocytes);
                }

            }
            else if(symptoms.contains("сильная боль в горле")){
                if(symptoms.contains("гиперлейкоцитоз")){
                    if(symptoms.contains("волыдри на горле"))
                        return new Answer(true, "Фарингит, Лечение: антибиотики широкого спектра, полоскать горло");
                    else if(symptoms.contains("стенки горла чистые")){
                        return  new Answer(true, "Бактериальная ангина, Лечение: антибиотики широкого спектра, полоскать горло");
                    }
                    else{
                        currentQuestion = questionAboutThroat;
                        return new Answer(false, questionAboutThroat);
                    }

                }
                else {
                    currentQuestion = questionAboutLeukocytes;
                    return new Answer(false, questionAboutLeukocytes);
                }
            }
        }

        return null;
    }

    public void answerToTherapist(String answer){
        if(currentQuestion.equals(questionAboutLeukocytes)){
            int number = Integer.parseInt(answer);
            if(number > 120){
                symptoms.add("гиперлейкоцитоз");
            }
            else{
                symptoms.add("лейкоциты в норме");
            }
        }
        if(currentQuestion.equals(questionAboutThroat)){
            if(answer.equals("да"))
                symptoms.add("волыдри на горле");
            else{
                symptoms.add("стенки горла чистые");
            }
        }
    }

    public void restart(){
        symptoms.clear();
        currentQuestion = null;
    }
}
