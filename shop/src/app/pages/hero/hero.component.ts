import { Component, signal, Signal } from "@angular/core";

@Component({
    templateUrl: './hero.component.html'
})
export class HeroComponent{
    name = signal('Ironman');
    age = signal(45);

    getHeroDescription(){
        return `${this.name()} - ${this.age()}`
    }

    changeHero(){
        this.name.set('Spiderman');
        this.age.set(22);
    }

    changeAge(){
        this.age.set(60);
    }

    resetHero(){
        this.name.set('Ironman');
        this.age.set(45);
    }

}