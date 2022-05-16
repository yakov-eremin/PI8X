package project.patterngenerator.patterns.creational;

import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import project.patterngenerator.patterns.Pattern;

/**
 * Класс для вывода реализации FactoryMethod
 */
public class FactoryMethod extends Pattern {

    /**
     * Конструктор, похож на конструктор паттерна Observer,
     * при этом автоматически паттерн будет внесен в соответствующий список, согласно его вида,
     * это нужно для оптимизации поиска паттерна определенного типа
     *
     * @param box обязательный VBox для паттерна (даже не думай передавать туда null)
     */
    public FactoryMethod(VBox box) {
        super(box);
    }

    private String insertDataInCode(String var0, String param0, String interface1, String class1, String class2) {
        return "public class Main {\n" +
                "\n" +
                "    public static void main(String[] args) {\n" +
                "        Creator creator = new Creator();\n" +
                "        creator." + var0 + " = \"" + class1 + "\";\n" +
                "        creator.create().get" + param0 + "();\n" +
                "        creator." + var0 + " = \"" + class2 + "\";\n" +
                "        creator.create().get" + param0 + "();\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class Creator {\n" +
                "    public String " + var0 + ";\n" +
                "    public I" + interface1 + " create() {\n" +
                "        if (" + var0 + " == \"" + class1 + "\")\n" +
                "            return new " + class1 + "();\n" +
                "        else\n" +
                "            return new " + class2 + "();\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "interface I" + interface1 + " {\n" +
                "    void get" + param0 + "();\n" +
                "}\n" +
                "class " + class1 + " implements I" + interface1 + " {\n" +
                "\n" +
                "    @Override\n" +
                "    public void get" + param0 + "() {\n" +
                "        System.out.println(\"" + class1 + "\");\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class " + class2 + " implements I" + interface1 + " {\n" +
                "\n" +
                "    @Override\n" +
                "    public void get" + param0 + "() {\n" +
                "        System.out.println(\"" + class2 + "\");\n" +
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
        return "creational";
    }

    /**
     * Возвращает название паттерна
     * @see project.patterngenerator.patterns.IPattern
     * @return название паттерна (на английском)
     */
    @Override
    public String getName() {
        return "FactoryMethod";
    }
}
