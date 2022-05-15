Feature: Therapist
  Scenario:
    Given I have my virtual computer therapist
    When I entered "сухой кашель" as first symptom
    And I entered "высокая температура" as second symptom
    And Therapist's question should be "Количество лейкоцитов в ОАК?"
    And I entered 200 as amount of leukocytes
    Then Therapist's diagnosis should be "ОРЗ, Лечение: антибиотики широкого спектра"

  Scenario:
    Given I have my virtual computer therapist
    When I entered "мокрый кашель" as first symptom
    And I entered "высокая температура" as second symptom
    And Therapist's question should be "Количество лейкоцитов в ОАК?"
    And I entered 200 as amount of leukocytes
    Then Therapist's diagnosis should be "ОРЗ, Лечение: антибиотики широкого спектра и АЦЦ"

  Scenario:
    Given I have my virtual computer therapist
    When I entered "сухой кашель" as first symptom
    And I entered "высокая температура" as second symptom
    And Therapist's question should be "Количество лейкоцитов в ОАК?"
    And I entered "100" as answer
    Then Therapist's diagnosis should be "ОРВИ, Лечение: лекраства не требуются, пить больше воды"

  Scenario:
    Given I have my virtual computer therapist
    When I entered "сильная боль в горле" as first symptom
    And I entered "высокая температура" as second symptom
    And Therapist's question should be "Количество лейкоцитов в ОАК?"
    And I entered "200" as answer
    And Therapist's question should be "Горло в волдырях?"
    And I entered "нет" as answer
    Then Therapist's diagnosis should be "Бактериальная ангина, Лечение: антибиотики широкого спектра, полоскать горло"

  Scenario:
    Given I have my virtual computer therapist
    When I entered "сильная боль в горле" as first symptom
    And I entered "высокая температура" as second symptom
    And Therapist's question should be "Количество лейкоцитов в ОАК?"
    And I entered "200" as answer
    And Therapist's question should be "Горло в волдырях?"
    And I entered "да" as answer
    Then Therapist's diagnosis should be "Фарингит, Лечение: антибиотики широкого спектра, полоскать горло"

  Scenario:
    Given I have my virtual computer therapist
    When I entered "кашель" as first symptom
    And I entered "одышка" as second symptom
    And Therapist's question should be "Курите?"
    And I entered "да" as answer
    Then Therapist's diagnosis should be "Не курите."
