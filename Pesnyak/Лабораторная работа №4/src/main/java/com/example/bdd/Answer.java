package com.example.bdd;

public class Answer {
    boolean isDiagnosis;
    String answer;

    public Answer(boolean isDiagnosis, String answer) {
        this.isDiagnosis = isDiagnosis;
        this.answer = answer;
    }

    public boolean isDiagnosis() {
        return isDiagnosis;
    }

    public String getAnswer() {
        return answer;
    }
}
