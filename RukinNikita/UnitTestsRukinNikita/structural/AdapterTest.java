package project.patterngenerator.patterns.structural;

import javafx.scene.layout.VBox;
import org.junit.jupiter.api.Test;
import project.patterngenerator.patterns.Pattern;
import project.patterngenerator.patterns.creational.Singleton;

import static org.junit.jupiter.api.Assertions.*;

class AdapterTest {

    @Test
    void notifyAllPatterns() {
        Pattern pattern = new Adapter(new VBox());
        pattern.notifyAllPatterns();
        assertTrue(pattern.getBox().isVisible());
    }

    @Test
    void get() {
        new Adapter(new VBox());
        Pattern pattern = Pattern.get("Adapter");
        assertEquals(pattern.getName(), "Adapter");
    }

    @Test
    void defineType() {
        new Adapter(new VBox());
        assertNotNull(Pattern.creational);
    }
}