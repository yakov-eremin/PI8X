package project.patterngenerator.patterns.creational;

import javafx.scene.layout.VBox;
import org.junit.jupiter.api.Test;
import project.patterngenerator.patterns.Pattern;

import static org.junit.jupiter.api.Assertions.*;

class FactoryMethodTest {

    @Test
    void notifyAllPatterns() {
        Pattern factory = new FactoryMethod(new VBox());
        factory.notifyAllPatterns();
        assertTrue(factory.getBox().isVisible());
    }

    @Test
    void get() {
        new FactoryMethod(new VBox());
        Pattern factory = Pattern.get("FactoryMethod");
        assertEquals(factory.getName(), "FactoryMethod");
    }

    @Test
    void defineType() {
        new FactoryMethod(new VBox());
        assertNotNull(Pattern.creational);
    }

}