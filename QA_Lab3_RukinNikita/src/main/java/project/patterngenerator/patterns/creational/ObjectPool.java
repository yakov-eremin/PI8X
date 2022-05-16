package project.patterngenerator.patterns.creational;

import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import project.patterngenerator.patterns.Pattern;

public class ObjectPool  extends Pattern {
    /**
     * Конструктор, похож на конструктор паттерна Observer,
     * при этом автоматически паттерн будет внесен в соответствующий список, согласно его вида,
     * это нужно для оптимизации поиска паттерна определенного типа
     *
     * @param box обязательный VBox для паттерна (даже не думай передавать туда null)
     */
    public ObjectPool(VBox box) {
        super(box);
    }

    private String insertDataInCode(String class1, String param1) {
        String var1 = class1.toLowerCase();
        return "public class Main {\n" +
                "\n" +
                "    public static void main(String[] args) {\n" +
                "        ObjectPool pool = new ObjectPool();\n" +
                "        // добавляем 5 объектов\n" +
                "        for (int i = 0; i < 5; i++) {\n" +
                "            " + class1 + " " + var1 + " = pool.get" + class1 + "();\n" +
                "            " + var1 + "." + param1 + " = String.valueOf(i);\n" +
                "            System.out.print(" + var1 + "." + param1 + " + \" \");\n" +
                "            pool.release" + class1 + "(" + var1 + "); // освобождаем место\n" +
                "        }\n" +
                "        System.out.println();\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class ObjectPool {\n" +
                "    List<" + class1 + "> used = new ArrayList<>();\n" +
                "    List<" + class1 + "> free = new ArrayList<>();\n" +
                "\n" +
                "    public " + class1 + " get" + class1 + "() {\n" +
                "        " + class1 + " " + var1 + ";\n" +
                "        if(free.isEmpty()) {\n" +
                "            " + var1 + " = new " + class1 + "();\n" +
                "            free.add(" + var1 + ");\n" +
                "        } else {\n" +
                "            " + var1 + " = free.get(0);\n" +
                "            used.add(" + var1 + ");\n" +
                "            free.remove(" + var1 + ");\n" +
                "        }\n" +
                "        return " + var1 + ";\n" +
                "    }\n" +
                "\n" +
                "    public void release" + class1 + "(" + class1 + " " + var1 + ") {\n" +
                "        used.remove(" + var1 + ");\n" +
                "        free.add(" + var1 + ");\n" +
                "    }\n" +
                "}\n" +
                "\n" +
                "class " + class1 + " {\n" +
                "    public String " + param1 + ";\n" +
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
        return insertDataInCode(text1.getText(),
                text2.getText());
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
        return "ObjectPool";
    }
}
