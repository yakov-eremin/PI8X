package com.example.bdd;

import java.util.Scanner;

public class BddApplication {

    public static void main(String[] args) {
        Therapist therapist = new Therapist();
        Scanner scanner = new Scanner(System.in);
        System.out.print("Ваш симптом: ");
        String symptom = scanner.nextLine();
        therapist.tellTherapistAboutSymptom(symptom);

        System.out.print("Ваш второй симптом: ");
        symptom = scanner.nextLine();
        therapist.tellTherapistAboutSymptom(symptom);
        Answer answer;
        while(true){
            answer = therapist.ask();
            System.out.println(answer.getAnswer());
            if(answer.isDiagnosis)
                break;
            else{
                String myAnswer = scanner.nextLine();
                therapist.answerToTherapist(myAnswer);
            }
        }
    }

}
