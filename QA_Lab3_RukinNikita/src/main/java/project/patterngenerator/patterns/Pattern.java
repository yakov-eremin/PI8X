package project.patterngenerator.patterns;

import javafx.scene.layout.VBox;
import java.util.ArrayList;
import java.util.List;

/**
 * Абстрактный класс Pattern, его реализация напоминает паттерн Observer,
 * но с некоторыми особенностями и дополнительными методами.
 * Имплементация в данном случае обязательна, так как отсутствует общая реализация некоторых методов,
 * а их конкретная реализация обязательна
 */
public abstract class Pattern implements IPattern {
    public static final List<Pattern> patterns = new ArrayList<>();
    public static final List<String> structural = new ArrayList<>();
    public static final List<String> creational = new ArrayList<>();
    public static final List<String> behavioral = new ArrayList<>();
    protected final VBox box;

    /**
     * Конструктор, похож на конструктор паттерна Observer,
     * при этом автоматически паттерн будет внесен в соответствующий список, согласно его вида,
     * это нужно для оптимизации поиска паттерна определенного типа
     * @param box обязательный VBox для паттерна (даже не думай передавать туда null)
     */
    public Pattern(VBox box) {
        this.box = box;
        patterns.add(this);
        defineType();
    }

    /**
     * Определяет вид паттерна по методу getType()
     * @see IPattern
     * и добавляет его в соответствующий список
     */
    private void defineType() {
        switch (this.getType()) {
            case "structural" -> structural.add(this.getName());
            case "creational" -> creational.add(this.getName());
            case "behavioral" -> behavioral.add(this.getName());
            default -> {
            }
        }
    }

    /**
     * Классический метод паттерна Observer,
     * оповещает все остальные паттерны об изменении своего состояния.
     * Нужен для сокрытия VBox других паттернов и отображения своего
     */
    public void notifyAllPatterns() {
        for (Pattern pattern : patterns) {
            // update
            pattern.box.setVisible(false);
        }
        this.box.setVisible(true);
    }

    /**
     * Возвращает паттерн на основе его названия (название на английском)
     * @param patternName название искомого паттерна (на английском)
     * @return объект класса Pattern с соответствующим именем
     */
    public static Pattern get(String patternName) {
        for (Pattern pattern : Pattern.patterns) {
            if (pattern.getName().equals(patternName)) {
                return pattern;
            }
        }
        return null;
    }

    public VBox getBox() {return  box;}
}
