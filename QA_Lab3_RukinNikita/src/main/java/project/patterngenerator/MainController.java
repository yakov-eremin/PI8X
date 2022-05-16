package project.patterngenerator;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.TextArea;
import javafx.scene.layout.VBox;
import project.patterngenerator.patterns.Pattern;
import project.patterngenerator.patterns.behavioral.Observer;
import project.patterngenerator.patterns.behavioral.Visitor;
import project.patterngenerator.patterns.creational.FactoryMethod;
import project.patterngenerator.patterns.creational.ObjectPool;
import project.patterngenerator.patterns.creational.Singleton;
import project.patterngenerator.patterns.structural.Adapter;
import project.patterngenerator.patterns.structural.Decorator;
import project.patterngenerator.patterns.structural.Flyweight;

/**
 * Контроллер, отвечает за связь между интерфейсом и моделью
 */
public class MainController {

    /**
     * VBox в которые вводится информация о паттернах (поля, названия классов, интерфейсы, методы)
     * Паттерн и соответствующий ему VBox
     * @see Pattern
     * FactoryMethod - factoryMethodVBox
     * ObjectPool - objectPoolVBox
     * Observer - observerVBox
     * Singleton - singletonVBox
     * Visitor - visitorVBox
     * Adapter - adapterVBox
     * Decorator - decoratorVBox
     * Flyweight - flyweightVBox
     */
    @FXML
    private VBox factoryMethodVBox, objectPoolVBox, observerVBox, singletonVBox, visitorVBox, adapterVBox, decoratorVBox, flyweightVBox;
    /**
     * Кнопка "Сгенерировать"
     */
    @FXML
    private Button generateButton;
    /**
     * typeChoiceBox - выпадающий список с выбором вида паттерна
     * patternChoiceBox - выпадающий список с выбором имени паттерна
     */
    @FXML
    private ChoiceBox<String> patternChoiceBox, typeChoiceBox;

    private ObservableList<String> patternAvailableChoices, typeAvailableChoices;
    /**
     * Поле для вывода сгенерированного кода
     */
    @FXML
    private TextArea textPatternArea;

    /**
     * Инициализация и создание событий
     */
    @FXML
    void initialize() {
        initializePatterns();

        typeAvailableChoices = FXCollections.observableArrayList("структурные", "порождающие", "поведенческие");
        typeChoiceBox.setItems(typeAvailableChoices);

        // Click Actions
        typeChoiceBoxClickAction();
        patternChoiceBoxClickAction();
    }

    /**
     * Нажатие на кнопку "Сгенерировать"
     */
    @FXML
    void generateClick() {
        textPatternArea.setText(Pattern.get(patternChoiceBox.getValue()).getCode());
    }

    /**
     * Реакция на нажатие ChoiceBox с выбором вида паттерна
     */
    void typeChoiceBoxClickAction() {
        typeChoiceBox.getSelectionModel().selectedIndexProperty().addListener((ov, value, new_value) -> {
            patternAvailableChoices = null;
            // делает кнопку "Сгенерировать" недоступной, так как изменился вид паттерна, а название еще не выбрано
            generateButton.setDisable(true);
            patternChoiceBox.getItems().clear();
            switch (typeAvailableChoices.get(new_value.intValue())) {
                case "структурные" -> {
                    patternAvailableChoices = FXCollections.observableArrayList(Pattern.structural);
                    patternChoiceBox.setItems(patternAvailableChoices);
                }
                case "порождающие" -> {
                    patternAvailableChoices = FXCollections.observableArrayList(Pattern.creational);
                    patternChoiceBox.setItems(patternAvailableChoices);
                }
                case "поведенческие" -> {
                    patternAvailableChoices = FXCollections.observableArrayList(Pattern.behavioral);
                    patternChoiceBox.setItems(patternAvailableChoices);
                }
                default -> {
                }
            }
        });
    }

    /**
     * Реакция на нажатие ChoiceBox с выбором имени паттерна
     */
    void patternChoiceBoxClickAction() {
        patternChoiceBox.getSelectionModel().selectedIndexProperty().addListener((ov, value, new_value) -> {
            if (patternAvailableChoices != null) {
                Pattern.get(patternAvailableChoices
                                .get(new_value.intValue()))
                        .notifyAllPatterns();
                generateButton.setDisable(false);
            }
        });
    }

    /**
     * Создание паттернов
     */
    private void initializePatterns() {
        new FactoryMethod(factoryMethodVBox);
        new ObjectPool(objectPoolVBox);
        new Observer(observerVBox);
        new Singleton(singletonVBox);
        new Visitor(visitorVBox);
        new Adapter(adapterVBox);
        new Decorator(decoratorVBox);
        new Flyweight(flyweightVBox);
    }
}