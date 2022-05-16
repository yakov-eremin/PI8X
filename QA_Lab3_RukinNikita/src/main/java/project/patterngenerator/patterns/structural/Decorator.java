package project.patterngenerator.patterns.structural;

import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import project.patterngenerator.patterns.Pattern;

public class Decorator extends Pattern {
    /**
     * Конструктор, похож на конструктор паттерна Observer,
     * при этом автоматически паттерн будет внесен в соответствующий список, согласно его вида,
     * это нужно для оптимизации поиска паттерна определенного типа
     *
     * @param box обязательный VBox для паттерна (даже не думай передавать туда null)
     */
    public Decorator(VBox box) {
        super(box);
    }

    private String insertDataInCode(String interface1, String class1, String class2) {
        String varI1 = interface1.toLowerCase();
        return "public class Main {\n" +
                "\n" +
                "    public static void main(String[] args) {\n" +
                "        I" + interface1 + " " + varI1 + " = new " + class2 + "(new " + class1 + "());\n" +
                "        " + varI1 + ".get" + interface1 + "();\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "interface I" + interface1 + " {\n" +
                "    void get" + interface1 + "();\n" +
                "}\n" +
                "\n" +
                "abstract class Decorator implements  I" + interface1 + " {\n" +
                "    I" + interface1 + " " + varI1 + ";\n" +
                "    public Decorator (I" + interface1 + " decorator) {\n" +
                "        "+ varI1 + " = decorator;\n" +
                "    }\n" +
                "\n" +
                "    public abstract void get" + interface1 + "();\n" +
                "}\n" +
                "\n" +
                "class " + class1 + " implements  I" + interface1 + " {\n" +
                "\n" +
                "    @Override\n" +
                "    public void get"+ interface1 + "() {\n" +
                "        System.out.println(\"" + class1 + "\");\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class " + class2 + " extends Decorator {\n" +
                "\n" +
                "    public " + class2 + "(I"+ interface1 + " decorator) {\n" +
                "        super(decorator);\n" +
                "    }\n" +
                "\n" +
                "    @Override\n" +
                "    public void get" + interface1 + "() {\n" +
                "        System.out.println(\"" + class2 + "\");\n" +
                "        " + varI1 + ".get" + interface1 + "();\n" +
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
        return "structural";
    }

    /**
     * Возвращает название паттерна
     * @see project.patterngenerator.patterns.IPattern
     * @return название паттерна (на английском)
     */
    @Override
    public String getName() {
        return "Decorator";
    }
}
