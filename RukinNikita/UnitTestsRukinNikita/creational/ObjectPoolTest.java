package project.patterngenerator.patterns.creational;

import javafx.scene.layout.VBox;
import org.junit.jupiter.api.Test;
import project.patterngenerator.patterns.Pattern;
import project.patterngenerator.patterns.behavioral.Visitor;

import static org.junit.jupiter.api.Assertions.*;

class ObjectPoolTest {

    @Test
    void notifyAllPatterns() {
        Pattern pattern = new ObjectPool(new VBox());
        pattern.notifyAllPatterns();
        assertTrue(pattern.getBox().isVisible());
    }

    @Test
    void get() {
        new ObjectPool(new VBox());
        Pattern pattern = Pattern.get("ObjectPool");
        assertEquals(pattern.getName(), "ObjectPool");
    }

    @Test
    void defineType() {
        new ObjectPool(new VBox());
        assertNotNull(Pattern.creational);
    }
}