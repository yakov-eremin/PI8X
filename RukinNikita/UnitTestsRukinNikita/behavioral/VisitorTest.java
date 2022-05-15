package project.patterngenerator.patterns.behavioral;

import javafx.scene.layout.VBox;
import org.junit.jupiter.api.Test;
import project.patterngenerator.patterns.Pattern;

import static org.junit.jupiter.api.Assertions.*;

class VisitorTest {

    @Test
    void notifyAllPatterns() {
        Pattern pattern = new Visitor(new VBox());
        pattern.notifyAllPatterns();
        assertTrue(pattern.getBox().isVisible());
    }

    @Test
    void get() {
        new Visitor(new VBox());
        Pattern pattern = Pattern.get("Visitor");
        assertEquals(pattern.getName(), "Visitor");
    }

    @Test
    void defineType() {
        new Visitor(new VBox());
        assertNotNull(Pattern.creational);
    }
}