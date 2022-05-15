package com.example.bdd;

import java.util.HashSet;
import java.util.Set;

public class Therapist {
    private final String questionAboutLeukocytes = "Количество лейкоцитов в ОАК?";
    Set<String> symptoms = new HashSet<>();
    String currentQuestion;

    public void tellTherapistAboutSymptom(String symptom){
        symptoms.add(symptom);
    }

    public Answer ask(){

        if((symptoms.contains("сухой кашель") || symptoms.contains("мокрый кашель")) && symptoms.contains("высокая температура")){
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
    }

}
