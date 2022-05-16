package project.patterngenerator.patterns.structural;

import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import project.patterngenerator.patterns.Pattern;

public class Adapter extends Pattern {
    /**
     * Конструктор, похож на конструктор паттерна Observer,
     * при этом автоматически паттерн будет внесен в соответствующий список, согласно его вида,
     * это нужно для оптимизации поиска паттерна определенного типа
     *
     * @param box обязательный VBox для паттерна (даже не думай передавать туда null)
     */
    public Adapter(VBox box) {
        super(box);
    }

    private String insertDataInCode(String class1, String class2, String class3, String param1) {
        String var1 = class1.toLowerCase();
        return "public class Main {\n" +
                "\n" +
                "    public static void main(String[] args) {\n" +
                "        " + class1 + " " + var1 + " = new " + class1 + "();\n" +
                "        " + var1 + ".doIt(new " + class2 + "());\n" +
                "        " + var1 + ".doIt(new Adapter(new " + class3 + "()));\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class " + class1 + " {\n" +
                "    void doIt(I" + class2 + " " + param1 + ") {\n" +
                "        " + param1 + ".doSomething();\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "interface I" + class2 + " {\n" +
                "    void doSomething();\n" +
                "}\n" +
                "\n" +
                "class " + class2 + " implements I" + class2 + " {\n" +
                "\n" +
                "    @Override\n" +
                "    public void doSomething() {\n" +
                "        System.out.println(\"" + class2 + "\");\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "interface I" + class3 + " {\n" +
                "    void doOperation();\n" +
                "}\n" +
                "\n" +
                "class " + class3 + " implements I" + class3 + " {\n" +
                "\n" +
                "    @Override\n" +
                "    public void doOperation() {\n" +
                "        System.out.println(\"" + class3 + "\");\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class Adapter implements I" + class2 + " {\n" +
                "    I" + class3 + " " + param1 + ";\n" +
                "\n" +
                "    public Adapter(I" + class3 + " " + param1 + ") {\n" +
                "        this." + param1 + " = " + param1 + ";\n" +
                "    }\n" +
                "\n" +
                "    @Override\n" +
                "    public void doSomething() {\n" +
                "        component.doOperation();\n" +
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
        return insertDataInCode(text1.getText(),
                text2.getText(),
                text3.getText(),
                text4.getText());
    }

    /**
     * Возвращает вид паттерна
     * @see project.patterngenerator.patterns.IPattern
     * @return вид паттерна (на английском)
     */
    @Override
    public String getType() {
        return "structural";
    }

    /**
     * Возвращает название паттерна
     * @see project.patterngenerator.patterns.IPattern
     * @return название паттерна (на английском)
     */
    @Override
    public String getName() {
        return "Adapter";
    }
}
