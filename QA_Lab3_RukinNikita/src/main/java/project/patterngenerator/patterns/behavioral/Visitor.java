package project.patterngenerator.patterns.behavioral;

import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import project.patterngenerator.patterns.Pattern;

public class Visitor extends Pattern {

    /**
     * Конструктор, похож на конструктор паттерна Observer,
     * при этом автоматически паттерн будет внесен в соответствующий список, согласно его вида,
     * это нужно для оптимизации поиска паттерна определенного типа
     *
     * @param box обязательный VBox для паттерна (даже не думай передавать туда null)
     */
    public Visitor(VBox box) {
        super(box);
    }

    private String insertDataInCode(String interface1, String class1, String class2) {
        String varI1 = interface1.toLowerCase();
        return "public class Main {\n" +
                "\n" +
                "    public static void main(String[] args) {\n" +
                "        I" + interface1 + " " + varI1 + " = new " + interface1 + "1();\n" +
                "        " + varI1 + ".doSmth(new " + class2 + "());\n" +
                "    }\n" +
                "\n" +
                "}\n" +
                "\n" +
                "interface I" + interface1 + " {\n" +
                "    void doSmth(Visitor visitor);\n" +
                "}\n" +
                "\n" +
                "class " + interface1 + "1 implements I" + interface1 + " {\n" +
                "\n" +
                "    @Override\n" +
                "    public void doSmth(Visitor visitor) {\n" +
                "        visitor.do" + interface1 + "1();\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class " + interface1 + "2 implements I" + interface1 + " {\n" +
                "\n" +
                "    @Override\n" +
                "    public void doSmth(Visitor visitor) {\n" +
                "        visitor.do" + interface1 + "2();\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "interface Visitor {\n" +
                "    void do" + interface1 + "1();\n" +
                "    void do" + interface1 + "2();\n" +
                "}\n" +
                "\n" +
                "class " + class1 + " implements Visitor {\n" +
                "    @Override\n" +
                "    public void do" + interface1 + "1() {\n" +
                "        System.out.println(\"" + class1 + " 1!\");\n" +
                "    }\n" +
                "\n" +
                "    @Override\n" +
                "    public void do" + interface1 + "2() {\n" +
                "        System.out.println(\"" + class1 + " 2!\");\n" +
                "    }\n" +
                "}\n" +
                "class " + class2 + " implements Visitor {\n" +
                "    @Override\n" +
                "    public void do" + interface1 + "1() {\n" +
                "        System.out.println(\"" + class2 + " 1!\");\n" +
                "    }\n" +
                "\n" +
                "    @Override\n" +
                "    public void do" + interface1 + "2() {\n" +
                "        System.out.println(\"" + class2 + " 2!\");\n" +
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
        return insertDataInCode(text1.getText(),
                text2.getText(),
                text3.getText());
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
        return "Visitor";
    }
}
