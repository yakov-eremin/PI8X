package project.patterngenerator.patterns.structural;

import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import project.patterngenerator.patterns.Pattern;

public class Flyweight extends Pattern {
    /**
     * Конструктор, похож на конструктор паттерна Observer,
     * при этом автоматически паттерн будет внесен в соответствующий список, согласно его вида,
     * это нужно для оптимизации поиска паттерна определенного типа
     *
     * @param box обязательный VBox для паттерна (даже не думай передавать туда null)
     */
    public Flyweight(VBox box) {
        super(box);
    }

    private String insertDataInCode(String mainClass, String method,
                                    String class1, String param11, String param12,
                                    String class2, String param21, String param22) {
        String mainVar = mainClass.toLowerCase();
        String var1 = class1.toLowerCase();
        String var2 = class2.toLowerCase();
        return "public class Main {\n" +
                "\n" +
                "    public static void main(String[] args) {\n" +
                "        " + class1 + "  " + var1 + " = new " + class1 + "(\"" + param11 + "\", \"" + param12 + "\");\n" +
                "        " + mainClass + " " + mainVar + " = new " + mainClass + "();\n" +
                "        for (int i = 0; i < 10; i++) {\n" +
                "            " + mainVar + ".generate" + class2 + "(" + var1 + ");\n" +
                "        }\n" +
                "        " + mainVar + "." + method + "();\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class " + class1 + " {\n" +
                "    private String " + param11 + ";\n" +
                "    private String " + param12 + ";\n" +
                "    public " + class1 + "(String " + param11 + ", String " + param12 + ") {\n" +
                "        this." + param11 + " = " + param11 + ";\n" +
                "        this." + param12 + " = " + param12 + ";\n" +
                "    }\n" +
                "    public void " + method + "() {\n" +
                "        System.out.print(" + param11 + " + \" \" + " + param12 + ");\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class " + class2 + " {\n" +
                "    public String " + param21 + ", " + param22 + ";\n" +
                "    " + class1 + " " + var1 + ";\n" +
                "    public " + class2 + "(String " + param21 + ", String " + param22 + ", " + class1 + " " + var1 + ") {\n" +
                "        this." + param21 + " = " + param21 + ";\n" +
                "        this." + param22 + " = " + param22 + ";\n" +
                "        this." + var1 + " = " + var1 + ";\n" +
                "    }\n" +
                "    public void " + method + "() {\n" +
                "        System.out.print(\"" + param21 + ": \" + " + param21 + " + \" " + param22 + ": \" + " + param22 + " + \" \");\n" +
                "        " + var2 + "." + method + "();\n" +
                "        System.out.println();\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class " + mainClass + " {\n" +
                "    private List<" + class2 + "> " + var2 + "s = new ArrayList<>();\n" +
                "\n" +
                "    public void generate" + class2 + "(" + class1 + " " + var1 + ") {\n" +
                "        trees.add(new " + class2 + "(" + param21 + ", " + param22 + ", " + var1 + "));\n" +
                "    }\n" +
                "    public void " + method + "() {\n" +
                "        for (" + class2 + " " + var2 + " : " + var2 + "s) {\n" +
                "            " + var2 + "." + method + "();\n" +
                "        }\n" +
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
        TextField text6 = (TextField) object.get(11);
        TextField text7 = (TextField) object.get(13);
        TextField text8 = (TextField) object.get(15);
        return insertDataInCode(text1.getText(),
                text2.getText(),
                text3.getText(),
                text4.getText(),
                text5.getText(),
                text6.getText(),
                text7.getText(),
                text8.getText());
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
        return "Flyweight";
    }
}
