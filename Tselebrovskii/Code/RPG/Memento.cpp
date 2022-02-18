#include "Memento.h"

std::string Memento::get_name()
{
    return std::string();
}

int Memento::get_height()
{
    return 0;
}

int Memento::get_width()
{
    return 0;
}

Environment* Memento::get_environment()
{
    return nullptr;
}

std::string Memento::get_bg_image()
{
    return std::string();
}

Background_generator* Memento::get_background_generator()
{
    return nullptr;
}

std::string Memento::get_snapshot_date()
{
    return std::string();
}

Memento::Memento()
{
}
