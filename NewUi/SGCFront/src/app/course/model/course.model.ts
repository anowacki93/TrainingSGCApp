export interface CourseModel {
    id: string;
    name: string;
    enrollments?: EnrollmentModel[];
}

export interface EnrollmentModel {
    studentId: string;
    courseId: string;
    grade?: Grade;
}

export enum Grade
{
    None = 0,
    Niedostateczny = 1,
    Dopuszcający = 2,
    Dostateczny = 3,
    Dobra = 4,
    Bardzo_dobra = 5,
    Celująca = 6
}