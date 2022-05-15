package project.patterngenerator.patterns.creational;

import javafx.scene.layout.VBox;
import org.junit.jupiter.api.Test;
import project.patterngenerator.patterns.Pattern;

import static org.junit.jupiter.api.Assertions.*;

class SingletonTest {

    @Test
    void notifyAllPatterns() {
        Pattern pattern = new Singleton(new VBox());
        pattern.notifyAllPatterns();
        assertTrue(pattern.getBox().isVisible());
    }

    @Test
    void get() {
        new Singleton(new VBox());
        Pattern pattern = Pattern.get("Singleton");
        assertEquals(pattern.getName(), "Singleton");
    }

    @Test
    void defineType() {
        new Singleton(new VBox());
        assertNotNull(Pattern.creational);
    }
}