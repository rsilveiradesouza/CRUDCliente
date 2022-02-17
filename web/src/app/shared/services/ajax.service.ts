import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AjaxService {
    public readonly baseUrl = "https://localhost:7193";

    constructor(private http: HttpClient) { }

    public formatUrl(url: string): string {
        if (url.indexOf('http') === 0) {
            return url;
        }
        if (url[0] !== '/') {
            url = '/' + url;
        }
        return this.baseUrl + url;
    }

    public get<T>(url: string, params: any = {}): Promise<T> {
        url = this.formatUrl(url);
        return lastValueFrom(this.http.get<T>(url, { params }));
    }

    public post<T>(url: string, body: any = {}) {
        url = this.formatUrl(url);

        const options = {
            headers: {
                'Content-Type': 'application/json; charset=UTF-8'
            }
        };

        return lastValueFrom(this.http.post<T>(url, body, options));
    }

    public put<T>(url: string, body: any = {}) {
        url = this.formatUrl(url);

        const options = {
            headers: {
                'Content-Type': 'application/json; charset=UTF-8'
            }
        };

        return lastValueFrom(this.http.put<T>(url, body, options));
    }

    public delete<T>(url: string, body: any = {}) {
        url = this.formatUrl(url);

        const options = {
            headers: {
                'Content-Type': 'application/json; charset=UTF-8'
            },
            body
        };

        return lastValueFrom(this.http.delete<T>(url, options));
    }
}
