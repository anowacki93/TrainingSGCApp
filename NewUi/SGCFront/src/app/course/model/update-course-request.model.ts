export interface UpdateCourseModel {
    id: string;
    name: string;
    enrollments: UpdateEnrollmentModel[];
}

export interface UpdateEnrollmentModel {
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