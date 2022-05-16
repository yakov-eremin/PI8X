package project.patterngenerator.patterns.creational;

import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import project.patterngenerator.patterns.Pattern;

public class Singleton extends Pattern {

    /**
     * Конструктор, похож на конструктор паттерна Observer,
     * при этом автоматически паттерн будет внесен в соответствующий список, согласно его вида,
     * это нужно для оптимизации поиска паттерна определенного типа
     *
     * @param box обязательный VBox для паттерна (даже не думай передавать туда null)
     */
    public Singleton(VBox box) {
        super(box);
    }

    private String insertDataInCode(String class1, String class2, String class3) {
        return "public class Main {\n" +
                "\n" +
                "    public static void main(String[] args) {\n" +
                "        " + class1 + ".getInstance().setInfo(\"" + class1 + "\");\n" +
                "        new " + class2 + "().show" + class1 + class2 + "();\n" +
                "        new " + class3 + "().show" + class1 + class3 + "();\n" +
                "    }\n" +
                "\n" +
                "}\n" +
                "\n" +
                "class " + class1 + " {\n" +
                "    private static " + class1 + " singleton = new " + class1 + "();\n" +
                "    private String info;\n" +
                "    private " + class1 + "() {\n" +
                "\n" +
                "    }\n" +
                "    static public " + class1 + " getInstance() {\n" +
                "        return singleton;\n" +
                "    }\n" +
                "\n" +
                "    public String getInfo() {\n" +
                "        return info;\n" +
                "    }\n" +
                "\n" +
                "    public void setInfo(String info) {\n" +
                "        this.info = info;\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class " + class2 + " {\n" +
                "    void show" + class1 + class2 + "() {\n" +
                "        System.out.println(\"" + class2 + ": \" + " + class1 + ".getInstance().getInfo());\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class " + class3 + " {\n" +
                "    void show" + class1 + class3 + "() {\n" +
                "        System.out.println(\"" + class3 + ": \" + " + class1 + ".getInstance().getInfo());\n" +
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
        return "creational";
    }

    /**
     * Возвращает название паттерна
     * @see project.patterngenerator.patterns.IPattern
     * @return название паттерна (на английском)
     */
    @Override
    public String getName() {
        return "Singleton";
    }
}
