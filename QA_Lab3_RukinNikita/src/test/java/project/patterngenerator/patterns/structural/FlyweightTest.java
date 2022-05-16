package project.patterngenerator.patterns.structural;

import javafx.scene.layout.VBox;
import org.junit.jupiter.api.Test;
import project.patterngenerator.patterns.Pattern;

import static org.junit.jupiter.api.Assertions.*;

class FlyweightTest {

    @Test
    void notifyAllPatterns() {
        Pattern pattern = new Flyweight(new VBox());
        pattern.notifyAllPatterns();
        assertTrue(pattern.getBox().isVisible());
    }

    @Test
    void get() {
        new Flyweight(new VBox());
        Pattern pattern = Pattern.get("Flyweight");
        assertEquals(pattern.getName(), "Flyweight");
    }

    @Test
    void defineType() {
        new Flyweight(new VBox());
        assertNotNull(Pattern.creational);
    }
}