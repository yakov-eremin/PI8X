package project.patterngenerator.patterns.behavioral;

import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import project.patterngenerator.patterns.Pattern;

public class Observer extends Pattern {
    /**
     * Конструктор, похож на конструктор паттерна Observer,
     * при этом автоматически паттерн будет внесен в соответствующий список, согласно его вида,
     * это нужно для оптимизации поиска паттерна определенного типа
     *
     * @param box обязательный VBox для паттерна (даже не думай передавать туда null)
     */
    public Observer(VBox box) {
        super(box);
    }

    private String insertDataInCode(String name1, String name2, String name3,
                                    String state1, String state2) {
        return "public class Main {\n" +
                "\n" +
                "    public static void main(String[] args) {\n" +
                "        Observer " + name1 + " = new Observer(\"" + name1 + "\");\n" +
                "        Observer " + name2 + " = new Observer(\"" + name2 + "\");\n" +
                "        Observer " + name3 + " = new Observer(\"" + name3 + "\");\n" +
                "        observer.setState(\"" + state1 + "\");\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class Observer {\n" +
                "    static List<Observer> observers = new ArrayList<>();\n" +
                "    String name;\n" +
                "    String state;\n" +
                "\n" +
                "    public Observer(String name) {\n" +
                "        this.name = name;\n" +
                "        this.state = \"" + state2 + "\";\n" +
                "        observers.add(this);\n" +
                "    }\n" +
                "\n" +
                "    public void setState(String state) {\n" +
                "        this.state = state;\n" +
                "        notifyAllObservers();\n" +
                "    }\n" +
                "\n" +
                "    private void notifyAllObservers() {\n" +
                "        for(Observer observer : observers) {\n" +
                "            observer.update();\n" +
                "        }\n" +
                "    }\n" +
                "    void update() {\n" +
                "        System.out.println(name + \": статус - \" + state);\n" +
                "    }\n" +
                "}";
    }

    /**
     * Возвращает реализацию паттерна
     * @see project.patterngenerator.patterns.IPattern
     * @return строку с реализацией паттерна
     */
    @Override
    public String getCode() {
        var object = box.getChildren();
        TextField text1 = (TextField) object.get(1);
        TextField text2 = (TextField) object.get(3);
        TextField text3 = (TextField) object.get(5);
        TextField text4 = (TextField) object.get(7);
        TextField text5 = (TextField) object.get(9);
        return insertDataInCode(text1.getText(),
                text2.getText(),
                text3.getText(),
                text4.getText(),
                text5.getText());
    }

    /**
     * Возвращает вид паттерна
     * @see project.patterngenerator.patterns.IPattern
     * @return вид паттерна (на английском)
     */
    @Override
    public String getType() {
        return "behavioral";
    }

    /**
     * Возвращает название паттерна
     * @see project.patterngenerator.patterns.IPattern
     * @return название паттерна (на английском)
     */
    @Override
    public String getName() {
        return "Observer";
    }
}
