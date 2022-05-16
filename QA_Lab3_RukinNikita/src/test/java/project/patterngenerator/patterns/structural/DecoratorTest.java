package project.patterngenerator.patterns.structural;

import javafx.scene.layout.VBox;
import org.junit.jupiter.api.Test;
import project.patterngenerator.patterns.Pattern;

import static org.junit.jupiter.api.Assertions.*;

class DecoratorTest {

    @Test
    void notifyAllPatterns() {
        Pattern pattern = new Decorator(new VBox());
        pattern.notifyAllPatterns();
        assertTrue(pattern.getBox().isVisible());
    }

    @Test
    void get() {
        new Decorator(new VBox());
        Pattern pattern = Pattern.get("Decorator");
        assertEquals(pattern.getName(), "Decorator");
    }

    @Test
    void defineType() {
        new Decorator(new VBox());
        assertNotNull(Pattern.creational);
    }
}